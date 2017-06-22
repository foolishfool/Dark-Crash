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
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
