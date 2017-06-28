/***
 * 
 *    Title: "Dark Crash" Project
 *           
 *    Script Function:
 *       Monitor chesses (user's operation)   
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

public class ChessTouch : MonoBehaviour {

    internal bool canSwap = false;

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
       // SelectChess();
    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseUp()
    {
       SelectChess();
    }

    internal void SelectChess()
    {
        //user clicks the first chess
        if (ChessOperation.instance.chessSelected1 == null)
        {
            ChessOperation.instance.chessSelected1 = this.gameObject.GetComponent<Chess>();  //the ChessTouch.cs and Chess.cs are both connect with a chess object
            ChessOperation.instance.chessSelected1.SelectMe();
        }
        else if (ChessOperation.instance.chessSelected2 == null)
        {
            ChessOperation.instance.chessSelected2 = this.gameObject.GetComponent<Chess>();
            ChessOperation.instance.chessSelected2.SelectMe();

            for (int i = 0; i < ChessOperation.instance.chessSelected1.chessNeighbour.Length; i++) 
            {
               if(ChessOperation.instance.chessSelected1.chessNeighbour[i] != null)
                { 
                if (ChessOperation.instance.chessSelected2.GetInstanceID() == ChessOperation.instance.chessSelected1.chessNeighbour[i].GetInstanceID()) //whether chessSelected 2 and chessSelected 1 are neighbour
                    {
                        canSwap = true;                 
                    }
                }
            }
     
            if (canSwap && ChessOperation.instance.isBusy == false )
            {
                SwapTwoChess.instance.SwapTwoChessObj(ChessOperation.instance.chessSelected1, ChessOperation.instance.chessSelected2);         
            }
           
        }
        else
        {
            //reset and prepare for the next click
            ChessOperation.instance.chessSelected1.UnSelectMe();
            ChessOperation.instance.chessSelected2.UnSelectMe();
            ChessOperation.instance.chessSelected1 = null;
            ChessOperation.instance.chessSelected2 = null;

        }
    }


}
