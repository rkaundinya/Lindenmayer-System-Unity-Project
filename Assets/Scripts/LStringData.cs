using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( fileName = "New LSystem Data Container", 
    menuName = "LSystem Data Container")]
public class LStringData : ScriptableObject
{
    public HashSet<char> LStringCharacterTypes = new HashSet<char>();
    public List<char> LSystemDummyCommands = new List<char>();
    public Dictionary<char, string> StringMutationRuleMap = new Dictionary<char, string>();
    public List <string> LSystemStrings = new List<string>();
    public Dictionary<char, ActionType> LSystemCharToActionMap 
        = new Dictionary<char, ActionType>();
    public GameObject prefabToSpawn;
    private LSystemSettings _lSystemSettings;

    public void CopyLSystemSettings( LSystemSettings lSystemSettings )
    {
        _lSystemSettings = lSystemSettings;
    }

    public LSystemSettings GetLSystemSettings()
    {
        return _lSystemSettings;
    }

    public void ClearAllData()
    {
        LStringCharacterTypes.Clear();
        LSystemDummyCommands.Clear();
        StringMutationRuleMap.Clear();
        LSystemStrings.Clear();
        LSystemCharToActionMap.Clear();
        prefabToSpawn = null;
        _lSystemSettings.ResetData();
    }

    public void PrintFinalLString()
    {
        Debug.Log(LSystemStrings[LSystemStrings.Count - 1]);
    }

    public void PrintAllLStringCharacters()
    {
        string allCharacters = "";
        foreach (var character in LStringCharacterTypes)
        {
            allCharacters += character.ToString();
        }

        Debug.Log ( "Stored LString Characters are: " + allCharacters );
    }
}

// TODO: Remove derivation from MonoBehaviour and using UnityEngine as well as 
// PrintFinalLString function once it is no longer needed. These are currently included
// for testing and debugging purposes only