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

public class Chess : MonoBehaviour {

    public Chess[] chessNeighbour = new Chess[4]; //each chess's neighbour left/right/up/down neigbhour, represent by 0/1/2/3

    internal bool canEliminate = false; //whether current chess can be eliminated

    internal string strNeighbourLeft1 = "Left1";
    internal string strNeighbourLeft2 = "Left2";
    internal string strNeighbourRight1 = "Right1";
    internal string strNeighbourRight2 = "Right2";
    internal string strNeighbourDown1 = "Down1";
    internal string strNeighbourDown2 = "Down2";
    internal string strNeighbourUp1 = "Up1";
    internal string strNeighbourUp2 = "Up2";

    // Use this for initialization
    void Start () {
		
	}


    /// <summary>
    /// allocate neighbour
    /// </summary>
    internal void AssignNeighbourNames()
    {
        //parameter check
        if (chessNeighbour == null || chessNeighbour.Length ==0)
        {
            Debug.LogError(string.Format("[Chess.cs/AssignNeighbour()] illegal parameter!, please check!"));
        }
        //left
        if (chessNeighbour[0] != null)
        {
            strNeighbourLeft1 = chessNeighbour[0].name;

            if (chessNeighbour[0].chessNeighbour[0] != null)
            {
                strNeighbourLeft2 = chessNeighbour[0].chessNeighbour[0].name;

            }
        }

        //right

        if (chessNeighbour[1] != null)
        {
            strNeighbourRight1 = chessNeighbour[1].name;

            if (chessNeighbour[1].chessNeighbour[1] != null)
            {
                strNeighbourRight2 = chessNeighbour[1].chessNeighbour[1].name;

            }
        }

        //up

        if (chessNeighbour[2] != null)
        {
            strNeighbourUp1 = chessNeighbour[2].name;

            if (chessNeighbour[2].chessNeighbour[2] != null)
            {
                strNeighbourUp2 = chessNeighbour[2].chessNeighbour[2].name;

            }
        }

        //down

        if (chessNeighbour[3] != null)
        {
            strNeighbourDown1 = chessNeighbour[3].name;

            if (chessNeighbour[3].chessNeighbour[3] != null)
            {
                strNeighbourDown2 = chessNeighbour[3].chessNeighbour[3].name;

            }
        }


    }

    //check whether a certain chess can be eliminate

    internal bool CanEliminateByChess(Chess chessObj)
    {
        bool canEliminate = false;
        if (chessObj) //if the chessObj exists, it will disappear when being eliminated
        {
            if (
                (chessObj.gameObject.name == strNeighbourLeft1 && chessObj.gameObject.name == strNeighbourLeft2) ||
                (chessObj.gameObject.name == strNeighbourLeft1 && chessObj.gameObject.name == strNeighbourRight1) ||
                (chessObj.gameObject.name == strNeighbourRight1 && chessObj.gameObject.name == strNeighbourRight2) ||
                (chessObj.gameObject.name == strNeighbourUp1 && chessObj.gameObject.name == strNeighbourUp2) ||
                (chessObj.gameObject.name == strNeighbourUp1 && chessObj.gameObject.name == strNeighbourDown1) ||
                (chessObj.gameObject.name == strNeighbourDown1 && chessObj.gameObject.name == strNeighbourDown2)
                )

            {
                canEliminate = true; //can be eliminated
            }

        }


        return canEliminate;
    }

    //set the flag of whether eliminate
    //the reason why we do not use CanEliminateByChess(Chess chessobj) to represent canEliminate is due to the flexibility
    internal void MakeFlagIfCanElimnate()
    {
        if (CanEliminateByChess(this))
            canEliminate = true;
        else
            canEliminate = false;
    }
    //test method
    /*   public void TestAssignNeighbour()
        {
            print("");
            print("");
            print("strNeighbourLeft1= " + strNeighbourLeft1);
            print("strNeighbourLeft2= " + strNeighbourLeft2);
            print("strNeighbourRight1= " + strNeighbourRight1);
            print("strNeighbourRight2= " + strNeighbourRight2);
            print("strNeighbourUp1= " + strNeighbourUp1);
            print("strNeighbourUp2= " + strNeighbourUp2);
            print("strNeighbourDown1= " + strNeighbourDown1);
            print("strNeighbourDown2= " + strNeighbourDown2);
        } 
        */

    /// <summary>
    /// destory  the chess
    /// </summary>
    
    internal void DestroyChess()
    {
        if (canEliminate)
        {
            Destroy(this.gameObject);
        }
    }

}
