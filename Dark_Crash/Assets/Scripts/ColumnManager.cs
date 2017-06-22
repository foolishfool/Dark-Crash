﻿/***
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

public class ColumnManager : MonoBehaviour {

    public static ColumnManager instance;  // can be use to pass values among classes in a hihg effieiency

    internal Column[] colArray = new Column[8];

    private void Awake()
    {
        instance = this; //this means current class's instance
    }


    // Use this for initialization
    void Start () {
        //initialize the "chess board"
        for (int i = 0; i < colArray.Length; i++)
        {
            GameObject newObject = new GameObject();
            colArray[i] = newObject.AddComponent<Column>();
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}