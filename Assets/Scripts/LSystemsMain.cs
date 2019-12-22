using System;
using System.Collections;
using UnityEngine;

public class LSystemsMain : MonoBehaviour
{
    [SerializeField]
    private LStringData lStringDataContainer;
    [SerializeField]
    private GameObject prefabToSpawn;
    [SerializeField]
    private RuleMap[] mutationRules;
    [SerializeField]
    private LSystemSettings lSystemSettings;

    [HideInInspector]
    public int openTab;
    [HideInInspector]
    public string currentTabName;

    private void Awake() 
    {
        InitializeLStringData();
        GenerateLStrings.GenerateStringMutations(lSystemSettings.axiom, 
            lSystemSettings.totalNumOfMutations, lStringDataContainer);
        lStringDataContainer.PrintFinalLString();
    }

    private void Start() 
    {
        LSystemReadStrings.ReadSpecificStringAction(lStringDataContainer);
    }

    private void Update() 
    {

    }

    private void InitializeLStringData()
    {
        lStringDataContainer.ClearAllData();
        AddUserInputtedRulesToLStringDataRuleMap();
        lStringDataContainer.prefabToSpawn = prefabToSpawn;
    }

    private void AddUserInputtedRulesToLStringDataRuleMap()
    {
        foreach (var rule in mutationRules)
        {
            LSystemGenerationRules.AddRuleToRuleMap(rule.charToMutate, 
                rule.stringToMutateTo, lStringDataContainer);
            if (rule.isADummyCommand)
            {
                AddDummyCharToLStringDummyCommands(rule.charToMutate, lStringDataContainer);
            }
            AddCharActionPairToLStringCharMap(rule.charToMutate, rule.actionType, 
                lStringDataContainer);
        }
    }

    private void AddDummyCharToLStringDummyCommands (char symbol, LStringData lStringData)
    {
        lStringData.LSystemDummyCommands.Add(symbol);
        Debug.Log("A dummy command has been added");
    }

    private void AddCharActionPairToLStringCharMap(char symbol, ActionType actionToDo, 
        LStringData lStringData)
    {
        lStringData.LSystemCharToActionMap.Add(symbol, actionToDo);
    }

    public LStringData GetLStringData()
    {
        return lStringDataContainer;
    }
}