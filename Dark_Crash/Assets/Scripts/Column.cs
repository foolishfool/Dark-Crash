/***
 * 
 *    Title: "Dark Crash" Project
 *           
 *    Script Function:
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
using UnityEngine;

public class Column : MonoBehaviour
{

    // Column is generated dynamically so there is no need to use static instance
    public int currentColumnNumber = -999; // current column number , -999 is easy to check error
                                           // Use this for initialization

    internal int needAddChessNumber = 0; //the number that new chess need to be added after elimination
    internal List<Chess> chessArray = new List<Chess>(); //the chess collection that current column contains
    


    void Start()
    {
        for (int row = 0; row < GameManager.instance.IntRowNumber; row++)
        {

            //get the prefabs
            GameObject prefabsObj = GameManager.instance.PrefablsArray[Random.Range(0, 6)];
            //clone prefabs 
            //GameManager.instance.ColumnSpace the space between columns
            GameObject cloneObj = Instantiate(prefabsObj, new Vector3(currentColumnNumber * GameManager.instance.ColumnSpace, -row, prefabsObj.transform.position.z), Quaternion.identity);
            // establish parent-child relationship
            cloneObj.transform.parent = this.transform;
            //specify the scale of chess
            cloneObj.transform.localScale = new Vector3(GameManager.instance.ChessScale, GameManager.instance.ChessScale, GameManager.instance.ChessScale);
            //store coloneobj into List<Chess>
            chessArray.Add(cloneObj.GetComponent<Chess>());
        }

    }

    //assign neighbour
    internal void AssignNeighbour()
    {
        for (int row = 0; row < chessArray.Count; row++) // list uses count not length
        {
            //left
            if (currentColumnNumber == 0)
            {
                chessArray[row].chessNeighbour[0] = null;
            }
            else
            {
                //@@@@@@@@@@@@@@@@@@@@ difficulty@@@@@@@@@@@@@@@@@@@@@@@@@@@2//
                chessArray[row].chessNeighbour[0] = ColumnManager.instance.colArray[currentColumnNumber - 1].chessArray[row];//left column's chess

            }
            //right

            if (currentColumnNumber == ColumnManager.instance.colArray.Length - 1)
            {
                chessArray[row].chessNeighbour[1] = null;
            }
            else
            {
                chessArray[row].chessNeighbour[1] = ColumnManager.instance.colArray[currentColumnNumber + 1].chessArray[row];//right column's chess
            }
            //up
            if (row == 0)
            {
                chessArray[row].chessNeighbour[2] = null;
            }
            else
            {
                chessArray[row].chessNeighbour[2] = chessArray[row - 1];//up chess in the same column
            }
            //down
            if (row == chessArray.Count - 1)
            {
                chessArray[row].chessNeighbour[3] = null;
            }
            else
            {
                chessArray[row].chessNeighbour[3] = chessArray[row + 1];//down chess in the same column

            }
        }

    }

    internal void AddNewChessByCurrentColumn()
    {
        //i represents the number of new added chesses
        for (int i = 1; i <= needAddChessNumber; i++)
        {
            //get the prefabs
            GameObject prefabsObj = GameManager.instance.PrefablsArray[Random.Range(0, 6)];
            //clone prefabs 
            //GameManager.instance.ColumnSpace the space between columns
            GameObject cloneObj = Instantiate(prefabsObj, new Vector3(currentColumnNumber * GameManager.instance.ColumnSpace, i, prefabsObj.transform.position.z), Quaternion.identity);
            // i, not -i because add chess on the top
            // establish parent-child relationship
            cloneObj.transform.parent = this.transform;
            //specify the scale of chess
            cloneObj.transform.localScale = new Vector3(GameManager.instance.ChessScale, GameManager.instance.ChessScale, GameManager.instance.ChessScale);
            //store coloneobj into List<Chess>
            //@@@@@@@@@@@@@@@@difficulty@@@@@@@@@@@@@@@@@@@@@@@@
            chessArray.Insert(0, cloneObj.GetComponent<Chess>()); //insert the chess collection form the top
        }
    }
}
