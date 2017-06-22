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

    internal string strNeighourLeft1 = "Left1";
    internal string strNeighourLeft2 = "Left2";
    internal string strNeighourRight1 = "Right1";
    internal string strNeighourRight2 = "Right2";
    internal string strNeighourDown1 = "Down1";
    internal string strNeighourDown2 = "Down2";
    internal string strNeighourUp1 = "Up1";
    internal string strNeighourUp2 = "Up2";

    // Use this for initialization
    void Start () {
		
	}
    //allocate neighbour


    internal void AssignNeighbourNames()
    {
        //parameter check
        if (chessNeighbour == null || chessNeighbour.Length ==0)
        {
            Debug.LogError(string.Format("[Chess.cs/AssignNeighbour()] illegal parameter!, please check!"));
        }
        //left
        AssignNeighbourName(strNeighourLeft1, strNeighourLeft2, 0);
        //right
        AssignNeighbourName(strNeighourRight1, strNeighourRight2, 0);
        //up
        AssignNeighbourName(strNeighourUp1, strNeighourUp2, 0);
        //down
        AssignNeighbourName(strNeighourDown1, strNeighourDown2, 0);

    }
    //assign name to neigbhour chesses
    internal void AssignNeighbourName(string neighbourString1, string neighbourString2, int neighbourNumber)
    {
        if (chessNeighbour[neighbourNumber] != null)
        {
            neighbourString1 = chessNeighbour[neighbourNumber].name;
            if (chessNeighbour[neighbourNumber].chessNeighbour[neighbourNumber] != null)
            {
                neighbourString2 = chessNeighbour[neighbourNumber].chessNeighbour[neighbourNumber].name;
            }
        }

    }

	// Update is called once per frame
	void Update () {
		
	}
}
