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

	// Use this for initialization
	void Start () {
		
	}

    private void OnMouseDown()
    {
        SelectChess();
    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseUp()
    {
       // SelectChess();
    }

    internal void SelectChess()
    {
        //user clicks the first chess
        if (ChessOperation.instance.chessSelected1 == null)
        {
            ChessOperation.instance.chessSelected1 = this.gameObject.GetComponent<Chess>();  //the ChessTouch.cs and Chess.cs are both connect with a chess object
        }
        else if (ChessOperation.instance.chessSelected2 == null)
        {
            ChessOperation.instance.chessSelected2 = this.gameObject.GetComponent<Chess>();
            SwapTwoChess.instance.SwapTwoChessObj(ChessOperation.instance.chessSelected1, ChessOperation.instance.chessSelected2);

        }
        else
        {
            //reset and prepare for the next click
            ChessOperation.instance.chessSelected1 = null;
            ChessOperation.instance.chessSelected2 = null;
        }
    }


}
