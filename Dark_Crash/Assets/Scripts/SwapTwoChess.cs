/***
 * 
 *    Title: "Dark Crash" Project
 *           
 *    Script Function: Swap Two Chess
 *           
 * 
 *    Description: 
 *  
 * 
 *    Date: 2017
 *    
 *    Version: 0.1
 *    
 *    Modify Recoder: Qiang Fu
 *   
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SwapTwoChess : MonoBehaviour
{

    public static SwapTwoChess instance;

    void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start()
    {

    }

    internal void SwapTwoChessObj(Chess chess1, Chess chess2)
    {
        ChessOperation.instance.isBusy = true; //when swapping users couldn't operation
        //check parameter
        if (chess1 == null || chess2 == null)
        {
            Debug.LogError("[SwapTwoChess.cs/SwapTwoChessObj] parameter loss");
        }
        //swap animation

        iTween.MoveTo(chess1.gameObject, chess2.gameObject.transform.position, 1f);
        iTween.MoveTo(chess2.gameObject, chess1.gameObject.transform.position, 1f);
        //core swap algorithm
        SwapTwoChessItem(chess1, chess2);
    }

    internal void SwapTwoChessItem(Chess chess1, Chess chess2)
    {
        Column chess1Column; //column that contains chess1
        Column chess2Column;
        int chess1ColumnIndex = -999;  //the index number that contains chess1
        int chess2ColumnIndex = -999;
        chess1Column = chess1.fromColumns;
        chess2Column = chess2.fromColumns;

        print("hess1.fromColumns" + chess1.fromColumns);
        print("hess2.fromColumns" + chess2.fromColumns);

        print("finshe djdjdjdjdjd"+ ChessOperation.instance.isSwapBack);


        if (chess1Column == null || chess2Column == null)
        {
            Debug.LogError("[SwapTwoChess.cs/SwapTwoChessItem] parameter error");
            return;
        }
        //get the index number of column that contains chess
        for (int i = 0; i < chess1Column.chessArray.Count; i++)
        {
            print(ChessOperation.instance.isSwapBack + "444444444");
            if (!ChessOperation.instance.isSwapBack)
            {
                if (chess1.GetInstanceID() == chess1Column.chessArray[i].GetInstanceID())
                {
                    print(chess1.GetInstanceID()+"111111");
                    chess1ColumnIndex = i;
                }
            }
            //if swapBack chess1.fromColumns and chess2.fromColumn didn't change
            else
            {
                if (chess1.GetInstanceID() == chess2Column.chessArray[i].GetInstanceID())
                {
                    chess1ColumnIndex = i;
                }
            }

        }

        for (int j = 0; j < chess2Column.chessArray.Count; j++)
        {
            if (!ChessOperation.instance.isSwapBack)
            {
                if (chess2.GetInstanceID() == chess2Column.chessArray[j].GetInstanceID())
                {
                    print(chess2.GetInstanceID() + "2222222");
                    chess2ColumnIndex = j;
                }

            }
            else
            {
                if (chess2.GetInstanceID() == chess1Column.chessArray[j].GetInstanceID())
                {
                    chess2ColumnIndex = j;
                }
            }

        }
        if (chess1ColumnIndex == -999 || chess2ColumnIndex == -999)
        {
            //because parameter error, call current level again
            Debug.LogError("SwapTwoChess.cs/SwapTwoChessItem parameter error ColumnIndex = -999");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
           // Application.LoadLevel(Application.loadedLevel); //old version
        }

        //update the parent-child relationship that column contains the chess
        //@@@@@@@@@@@@@@@@@difficulty@@@@@@@@@@@@@@
        chess1.transform.parent = chess2Column.transform;   
        chess2.transform.parent = chess1Column.transform;
 
        chess1Column.chessArray.RemoveAt(chess1ColumnIndex);
        chess1Column.chessArray.Insert(chess1ColumnIndex, chess2);
        print(chess1Column.chessArray[chess1ColumnIndex].GetInstanceID() + "66666666");
        chess2Column.chessArray.RemoveAt(chess2ColumnIndex);
        chess2Column.chessArray.Insert(chess2ColumnIndex, chess1);
        print(chess2Column.chessArray[chess2ColumnIndex].GetInstanceID() + "7777777");



        //check the elimination circularly
        ChessOperation.instance.StartCoroutine("CheckIfCanEliminate");

        if (ChessOperation.instance.chessSelected1 != null && ChessOperation.instance.chessSelected2 != null)
        {
            //reset parameter
            //@@@@@@@@@@@@@@@@@difficulty@@@@@@@@@@@@@@
            ChessOperation.instance.chessSelected1.UnSelectMe(); //become dark
            ChessOperation.instance.chessSelected2.UnSelectMe();

            ChessOperation.instance.chessSwaped1 = ChessOperation.instance.chessSelected1;
            ChessOperation.instance.chessSwaped2 = ChessOperation.instance.chessSelected2;

            ChessOperation.instance.chessSelected1 = null;
            ChessOperation.instance.chessSelected2 = null;

            print(ChessOperation.instance.isSwapBack + ";;;;;;;");



            ChessOperation.instance.isBusy = false;
        }
        else
        {
            if (ChessOperation.instance.isSwapBack)
            {
                //reset chessSwap
                ChessOperation.instance.chessSwaped1 = null;
                ChessOperation.instance.chessSwaped2 = null;
                ChessOperation.instance.isSwapBack = false;
                print("333333333    ");
            }
        }




    }
}
