/***
 * 
 *    Title: "Dark Crash" Project
 *           
 *    Script Function:
 *           
 * 
 *    Description: 
 *      
 *    The  whole game manager, control the game at a macro level
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

public class GameManager : MonoBehaviour {
     
    

    public GameObject[] PrefablsArray;
    public int IntRowNumber = 5; // the row number of current scene , dynamically generate columns
    public float ColumnSpace = 1f; // the space between clumns
    public float ChessScale = 1f;  // the scale of one single chess
    public ParticleSystem[] ParticleArray;
    public static GameManager instance;  // can be use to pass values among classes in a hihg effieiency
    private void Awake()
    {
        instance = this; //this means current class's instance
    }

    // Use this for initialization
    void Start () {
		//initialize the "chess board"
	}
	

}
