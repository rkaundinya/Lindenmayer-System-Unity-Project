using System;
using UnityEngine;

public class LSystemsMain : MonoBehaviour
{
    // LSystemGenerationRules testObject = new LSystemGenerationRules();
    // LSystemGenerationRules lSystemGenerationRules = new LSystemGenerationRules();
    LStringData lStringData = new LStringData();

    private void Awake() 
    {
        LSystemGenerationRules.AddRuleToRuleMap('F', "F-F", lStringData);
        AddCharActionPairToLStringCharMap('F', 
            new Action<GameObject>(LSystemActions.TestFunc2), lStringData);
        GenerateLStrings.GenerateStringMutations("F", 3, lStringData);
    }

    private void Start() 
    {
        Debug.Log(lStringData.LSystemCharToActionMap.ContainsKey('F'));
        Debug.Log(lStringData.LSystemStrings.Count);
        LSystemReadStrings.ReadSpecificStringAction(lStringData.LSystemStrings, gameObject, 
            lStringData);
    }

    private void AddDummyCharToLStringDummyCommands (char symbol, LStringData lStringData)
    {
        lStringData.LSystemDummyCommands.Add(symbol);
    }

    private void AddCharActionPairToLStringCharMap(char symbol, Delegate actionToDo, 
        LStringData lStringData)
    {
        lStringData.LSystemCharToActionMap.Add(symbol, actionToDo);
    }
}