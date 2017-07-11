/***
 * 
 *    Title: "Dark Crash" Project
 *           
 *    Script Function:
 *           
 * 
 *    Description: 
 *      
 *    Dynamically manage the chess
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
    internal Chess chessSelected1;  //the first chess that user selected
    internal Chess chessSelected2; //the second chess that user selected
    internal Chess chessSwaped1; //the chess1 that just has been swaped, is used for swapping back
    internal Chess chessSwaped2; //the chess2 that just has been swaped
    internal bool isBusy = false; //is the system busy now (controling the user's operation)
    internal bool isSwapBack = false; // whether swap back

    private void Awake()
    {
        instance = this; //this means current class's instance
    }

    // Use this for initialization
    void Start() {
        AudioManager.SetAudioBackgroundVolumns(0.4f);
        AudioManager.SetAudioEffectVolumns(1f);
        AudioManager.PlayBackground("Theme Song");
       //Invoke("TestNeighbour", 1f);     
       StartCoroutine("CheckIfCanEliminate");
    }
    //check current board whether need to be eliminated

    IEnumerator CheckIfCanEliminate()
    {
        //@@@@@@@@@@@@@difficulty@@@@@@@@@@@@@@
        //if don't wait all the Start() may be implemented and have values for ChessArray[]
        yield return new WaitForSeconds(0.2f);

        isBusy = true;

        AssignNeighbour(); //assign neighbour
  
        CheckIfExitEliminateOption();
        //check whether current board has chess that can be eliminated

        yield return new WaitForSeconds(0.5f);

        if (ifExistEliminateOption)
        {

            //eliminate all chesses that can be eliminated
            DestroryIfCanEliminate();
            yield return new WaitForSeconds(0.2f);
            // add new chess
            AddNewChessByTop();
            yield return new WaitForSeconds(0.5f);
            //new cheess falling down animation
            PlayNewChessDropDown();
            yield return new WaitForSeconds(0.2f);
            //iteratively check
            StartCoroutine("CheckIfCanEliminate");
        }

        else
        {
            yield return new WaitForSeconds(0.5f);
            isBusy = false;

            print(chessSwaped1 + "kkkkk" + chessSwaped2);
            if (chessSwaped1 != null && chessSwaped2 != null)

            {
                print("2222");
                isSwapBack = true;
                SwapTwoChess.instance.SwapTwoChessObj(chessSwaped1, chessSwaped2);
              
            }
                
            print("there is no chess to be eliminated");
            
            
        }

    }
    //add new chess

    //check current board whether can be eliminated and set flag
    private void CheckIfExitEliminateOption()
    {
        ifExistEliminateOption = false;//after every time check reset ifExistEliminateOption all it will always be true once it becomes true

        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++)
        {
            for (int row = 0; row < ColumnManager.instance.colArray[col].chessArray.Count; row++)
            {
                ColumnManager.instance.colArray[col].chessArray[row].MakeFlagIfCanElimnate();
                if ( ColumnManager.instance.colArray[col].chessArray[row].canEliminate)
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

    //new chess falls down
    internal void PlayNewChessDropDown()
    {
        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++)
        {
            //each column plays drop down animation
            ColumnManager.instance.colArray[col].PlayNewChessDropDown();
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
                AudioManager.PlayAudioEffectA("Whop");
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

