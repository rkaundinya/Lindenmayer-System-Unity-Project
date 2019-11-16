using System;
using System.Collections.Generic;
using UnityEngine;

public class LSystemsMain : MonoBehaviour
{
    [SerializeField]
    private RuleMap[] mutationRules;

    LStringData lStringData = new LStringData();

    private void Awake() 
    {
        AddUserInputtedRulesToLStringDataRuleMap();
        // LSystemGenerationRules.AddRuleToRuleMap('F', "F-F", lStringData);
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

    private void AddUserInputtedRulesToLStringDataRuleMap()
    {
        foreach (var rule in mutationRules)
        {
            LSystemGenerationRules.AddRuleToRuleMap(rule.charToMutate, 
                rule.stringToMutateTo, lStringData);
        }
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

[Serializable]
public struct RuleMap
{
    public char charToMutate;
    public string stringToMutateTo;
}