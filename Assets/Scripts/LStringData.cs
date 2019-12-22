using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "New LSystem Data Container", 
    menuName = "LSystem Data Container")]
public class LStringData : ScriptableObject
{
    public List <string> LSystemStrings = new List<string>();
    public List<char> LSystemDummyCommands = new List<char>();
    public Dictionary<char, string> StringMutationRuleMap = new Dictionary<char, string>();
    public Dictionary<char, ActionType> LSystemCharToActionMap 
        = new Dictionary<char, ActionType>();
    public GameObject prefabToSpawn;

    public void ClearAllData()
    {
        LSystemStrings.Clear();
        LSystemDummyCommands.Clear();
        StringMutationRuleMap.Clear();
        LSystemCharToActionMap.Clear();
        prefabToSpawn = null;
    }

    public void PrintFinalLString()
    {
        Debug.Log(LSystemStrings[LSystemStrings.Count - 1]);
        Console.Write(LSystemStrings[LSystemStrings.Count - 1]);
    }
}

// TODO: Remove derivation from MonoBehaviour and using UnityEngine as well as 
// PrintFinalLString function once it is no longer needed. These are currently included
// for testing and debugging purposes only