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
    private void Awake()
    {
        instance = this; //this means current class's instance
    }


    // Use this for initialization
    void Start () {

        Invoke("AssignNeighbour", 0.5f); //0.5 second delay , after UI is built
        
        Invoke("TestNeighbour", 1f);
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

    internal void TestNeighbour()
    {
        for (int col = 0; col < ColumnManager.instance.colArray.Length; col++) //each column
        {
            print(string.Format("col = {0}", col));
            for (int row = 0; row < ColumnManager.instance.colArray[col].chessArray.Count; row++) //each chess
            {
                print(string.Format("row = {0}", row));
                 ColumnManager.instance.colArray[col].chessArray[row].AssignNeighbourNames();
                //test
               // ColumnManager.instance.colArray[col].chessArray[row].TestAssignNeighbour();
            }
        }

    }
}
