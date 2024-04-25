using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class readInput : MonoBehaviour
{
    private string username;

    //Reads what the user puts in the input field
    private void ReadStringInput(string s){
        username = s;
        Debug.Log("Username: " + s);
    }
}
