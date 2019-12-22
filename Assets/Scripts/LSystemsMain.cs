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
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float speed = 3.0f;
    private float startTime; 
    private float journeyLength = 10f;
    private bool readLStringsFuncCalled = false;

    [HideInInspector]
    public int openTab;
    [HideInInspector]
    public string currentTabName;

    // private LStringData lStringData = new LStringData();

    private void Awake() 
    {
        lStringDataContainer.ClearAllData();
        AddUserInputtedRulesToLStringDataRuleMap();
        // LSystemGenerationRules.AddRuleToRuleMap('F', "F-F", lStringData);
        AddCharActionPairToLStringCharMap('F', 
            ActionType.MOVE_OBJECT, lStringDataContainer);
        lStringDataContainer.prefabToSpawn = prefabToSpawn;
        GenerateLStrings.GenerateStringMutations(lSystemSettings.axiom, 
            lSystemSettings.totalNumOfMutations, lStringDataContainer);
        lStringDataContainer.PrintFinalLString();
    }

    private void Start() 
    {
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(1,1,journeyLength);
        startTime = Time.time;
        // MoveCube();

        LSystemReadStrings.ReadSpecificStringAction(lStringDataContainer);
    }

    private void Update() 
    {
        /* if (!readLStringsFuncCalled)
        {
            LSystemReadStrings.ReadSpecificStringAction(gameObject, lStringData.LSystemStrings, 
                lStringData, lSystemSettings);
            readLStringsFuncCalled = true;
        } */
    }

    private void MoveCube()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        
        while (fractionOfJourney < 1)
        {
            distCovered = (Time.time - startTime) * speed;
            fractionOfJourney = distCovered / journeyLength;
            Debug.Log("Cube is still traveling");
            transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        }
        if (fractionOfJourney >= 1)
        {}
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