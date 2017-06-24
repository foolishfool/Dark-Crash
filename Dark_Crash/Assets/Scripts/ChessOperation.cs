/***
 * 
 *    Title: "Dark Crash" Project
 *           
 *    Script Function:
 *           
 * 
 *    Description: 
 *      
 *     Dynamically manage the chess
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
using UnityEngine;

public class ChessOperation : MonoBehaviour {

    public static ChessOperation instance;  // can be use to pass values among classes in a hihg effieiency
    internal bool ifExistEliminateOption = false; //current board can eliminate

    private void Awake()
    {
        instance = this; //this means current class's instance
    }

    // Use this for initialization
    void Start() {

        //Invoke("TestNeighbour", 1f);

        //check current board whether need to be eliminated
        StartCoroutine("CheckIfCanEliminate");

    }

    IEnumerator CheckIfCanEliminate()
    {
        yield return new WaitForSeconds(0.5f);

        AssignNeighbour(); //assign neighbour

        CheckIfExitEliminateOption();
        //check whether current board has chess that can be eliminated
        yield return new WaitForSeconds(0.5f);

        if (ifExistEliminateOption)
        {
            //eliminate all chesses that can be eliminated
            DestroryIfCanEliminate();
            // add new chess
            AddNewChessByTop();
            //new cheess falling down animation

            //iteratively check

            //StartCoroutine("CheckIfCanEliminate");
        }

        else
        {
            print("there is no chess to be eliminated");
        }

    }
    //add new chess

    //check current board whether can be eliminated and set flag
    private void CheckIfExitEliminateOption()
    {
        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++)
        {
            for (int row = 0; row < ColumnManager.instance.colArray[col].chessArray.Count; row++)
            {
                ColumnManager.instance.colArray[col].chessArray[row].MakeFlagIfCanElimnate();
                if (ColumnManager.instance.colArray[col].chessArray[row].canEliminate)
                {
                    ifExistEliminateOption = true; 
                    // couldn't return here, or other chesses won't be set flag
                }

            }
        }
    }

    private void DestroryIfCanEliminate()
    {
        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++)
        {
            for (int row = 0; row < ColumnManager.instance.colArray[col].chessArray.Count; row++)
            {
                ColumnManager.instance.colArray[col].chessArray[row].DestroyChess();

            }
        }

    }

    //board assignes neighbour

    internal void AssignNeighbour()
    {
        //ColumnManager assigns the neighbours to each chess
        ColumnManager.instance.AssignNeighbour();
        //Assign each chess a string name
        AssignNeighbourNamesEveryChess();
    }

    private void AssignNeighbourNamesEveryChess()
    {

        ColumnManager.instance.AssignNeighbour();
        //each chess is transfered  into 8 nighbour character strings 
        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++) //each column
        {
            for (int row = 0; row < ColumnManager.instance.colArray[col].chessArray.Count; row++) //each chess
            {
                ColumnManager.instance.colArray[col].chessArray[row].AssignNeighbourNames();
            }
        }
    }

    private void AddNewChessByTop()
    {
        //calculate the number of chess to be added for each column

        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++) //each column
        {
            for (int row = 0; row < ColumnManager.instance.colArray[col].chessArray.Count; row++) //each chess
            {
                if (ColumnManager.instance.colArray[col].chessArray[row].canEliminate)
                {
                    // the number of each column's adding chess
                    ++ColumnManager.instance.colArray[col].needAddChessNumber;
                   
                }
            }
        }

        //chess collection in each column need to remove  the script of chesses already be eliminated.
        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++)
        {
            // for (int row = 0; row < ColumnManager.instance.colArray[col].chessArray.Count; row++) 
            //current method is wrong
            //@@@@@@@@@@@@@@@@@@@@@@@@difficulty@@@@@@@@@@@@@@@@@@@@@@@@
            //after remove the chessArray.Count will change and each time the loop time will be different, so wil need to reverse the loop
            for (int row = ColumnManager.instance.colArray[col].chessArray.Count -1 ; row >=0; row--)
            { 
                if (ColumnManager.instance.colArray[col].chessArray[row].canEliminate)
                {
                    ColumnManager.instance.colArray[col].chessArray.RemoveAt(row);
      
                }
            }
        }

        // add new chess
        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++)
        {
            ColumnManager.instance.colArray[col].AddNewChessByCurrentColumn();
        }
    }
}




 /*
  *test methods  test assign neighbour methods
  * internal void TestNeighbour()
    {
        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++) //each column
        {
      
            for (int row = 0; row < ColumnManager.instance.colArray[col].chessArray.Count; row++) //each chess
            {            
                 ColumnManager.instance.colArray[col].chessArray[row].AssignNeighbourNames();
                //test
               // ColumnManager.instance.colArray[col].chessArray[row].TestAssignNeighbour();
            }
        }

    }
  */

