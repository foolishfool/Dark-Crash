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

public class Column : MonoBehaviour {

    // Column is generated dynamically so there is no need to use static instance
    public int currentColumnNumber = -999; // current column number , -999 is easy to check error
	// Use this for initialization
	void Start () {
        for (int row = 0; row < GameManager.instance.IntRowNumber; row++)
        {
           
            //get the prefabs
            GameObject prefabsObj = GameManager.instance.PrefablsArray[Random.Range(0, 6)];
            //clone prefabs 
            //GameManager.instance.ColumnSpace the space between columns
            GameObject cloneObj = Instantiate(prefabsObj, new Vector3(currentColumnNumber *GameManager.instance.ColumnSpace, -row, prefabsObj.transform.position.z), Quaternion.identity);
            // establish parent-child relationship
            cloneObj.transform.parent = this.transform;
            //specify the scale of chess
            cloneObj.transform.localScale = new Vector3(GameManager.instance.ChessScale, GameManager.instance.ChessScale, GameManager.instance.ChessScale);
         



        }
	
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
