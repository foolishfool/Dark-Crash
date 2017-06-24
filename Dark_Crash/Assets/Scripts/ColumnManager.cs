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
            //give name to each column
            newObject.name = "Column_" + i;
            //establish parent-child relationship
            newObject.transform.parent = this.transform;
            //number the column
            colArray[i].currentColumnNumber = i;
        }
    }

    internal void AssignNeighbour()
    {
        for (int i = 0; i < colArray.Length; i++)
        {
            //each column is assigned a neighbour
            colArray[i].AssignNeighbour();
        }
    }
}
