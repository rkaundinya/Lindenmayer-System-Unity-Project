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
    private LSystemCharActionPairs[] charActionPairs;
    [SerializeField]
    private LSystemSettings lSystemSettings;
    private int numOfLStringCharTypes;

    [HideInInspector]
    public int openTab;
    [HideInInspector]
    public string currentTabName;

    private void Awake() 
    {
        InitializeLStringData();
        GenerateLStrings.GenerateStringMutations(lSystemSettings.axiom, 
            lSystemSettings.totalNumOfMutations, lStringDataContainer);
        // lStringDataContainer.PrintFinalLString();
    }

    private void Start() 
    {
        LSystemReadStrings.ReadFinalString(lStringDataContainer);
    }

    private void InitializeLStringData()
    {
        lStringDataContainer.ClearAllData();
        AddUniqueUserInputCharsToLStringCharTypes();
        AddUserInputtedRulesToLStringDataRuleMap();
        lStringDataContainer.prefabToSpawn = prefabToSpawn;
        lStringDataContainer.CopyLSystemSettings( lSystemSettings );
    }

    public void OnEditorDataUpdate()
    {
        lStringDataContainer.LStringCharacterTypes.Clear();
        AddUniqueUserInputCharsToLStringCharTypes();
        UpdateNumOfCharActionPairs();
        UpdateCharOfEachCharActionPair();
    }

    private void AddUserInputtedRulesToLStringDataRuleMap()
    {
        foreach (var rule in mutationRules)
        {
            LSystemGenerationRules.AddRuleToRuleMap(rule.charToMutate, 
                rule.stringToMutateTo, lStringDataContainer);
        }

        foreach ( var pair in charActionPairs )
        {
            if ( pair.isADummyCommand )
            {
                lStringDataContainer.LSystemDummyCommands.Add(pair.character);
            }
            AddCharActionPairToLStringCharMap( pair.character, pair.actionType, 
                lStringDataContainer );
        }
    }

    private void AddUniqueUserInputCharsToLStringCharTypes()
    {
        foreach (var rule in mutationRules)
        {
            foreach ( var character in rule.stringToMutateTo )
            {
                if ( lStringDataContainer.LStringCharacterTypes.Contains ( 
                    character ) == false )
                {
                    lStringDataContainer.LStringCharacterTypes.Add(character);
                }  
            }

            if (lStringDataContainer.LStringCharacterTypes.Contains (
                rule.charToMutate ) == false )
            {
                lStringDataContainer.LStringCharacterTypes.Add( rule.charToMutate );
            }
        }

        foreach (var character in lSystemSettings.axiom)
        {
            if ( lStringDataContainer.LStringCharacterTypes.Contains ( character ) 
                == false)
            {
                lStringDataContainer.LStringCharacterTypes.Add( character );
            }
        }

        numOfLStringCharTypes = lStringDataContainer.LStringCharacterTypes.Count;
    }

    private void AddCharActionPairToLStringCharMap(char symbol, ActionType actionToDo, 
        LStringData lStringData)
    {
        lStringData.LSystemCharToActionMap.Add( symbol, actionToDo );
    }

    public LStringData GetLStringData()
    {
        return lStringDataContainer;
    }

    private void UpdateNumOfCharActionPairs()
    {
        Array.Resize( ref charActionPairs, numOfLStringCharTypes );
    }

    private void UpdateCharOfEachCharActionPair()
    {
        if ( charActionPairs.Length == lStringDataContainer.LStringCharacterTypes.Count )
        {
            int count = 0;
            foreach ( var character in lStringDataContainer.LStringCharacterTypes )
            {
                charActionPairs[count].character = character;
                ++count;
            }
        }
        else
        {
            Debug.LogError( "Length of Char Action Pairs and saved character types does not match" );
        }
    }
}