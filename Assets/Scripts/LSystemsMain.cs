using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemsMain : MonoBehaviour
{
    [SerializeField]
    private RuleMap[] mutationRules;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float speed = 3.0f;
    private float startTime; 
    private float journeyLength = 10f;
    private bool movementFinished = false;

    LStringData lStringData = new LStringData();

    private void Awake() 
    {
        AddUserInputtedRulesToLStringDataRuleMap();
        // LSystemGenerationRules.AddRuleToRuleMap('F', "F-F", lStringData);
        AddCharActionPairToLStringCharMap('F', 
            new Action<GameObject>(LSystemActions.MoveForward), lStringData);
        GenerateLStrings.GenerateStringMutations("F", 2, lStringData);
    }

    private void Start() 
    {
        Debug.Log(lStringData.StringMutationRuleMap.ContainsKey('X'));
        Debug.Log(lStringData.LSystemStrings.Count);

        startPosition = transform.position;
        endPosition = startPosition + new Vector3(1,1,journeyLength);
        startTime = Time.time;
        // StartCoroutine(LSystemActions.MoveForward(gameObject, 1f, 10f));
        /* LSystemReadStrings.ReadSpecificStringAction(lStringData.LSystemStrings, gameObject, 
            lStringData); */
    }

    private void Update() 
    {
        LSystemActions.MoveCube(gameObject, speed, journeyLength, startTime, startPosition, endPosition);
        /* if (movementFinished == false)
        {
            MoveCube();
        } */
        // MoveCube();
    }

    private void MoveCube()
    {
        movementFinished = false;
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        if (distCovered == journeyLength)
        {
            movementFinished = true;
            Debug.Log("Movement finished is " + movementFinished);
        }
    }

    private void AddUserInputtedRulesToLStringDataRuleMap()
    {
        foreach (var rule in mutationRules)
        {
            LSystemGenerationRules.AddRuleToRuleMap(rule.charToMutate, 
                rule.stringToMutateTo, lStringData);
            if (rule.isADummyCommand)
            {
                AddDummyCharToLStringDummyCommands(rule.charToMutate, lStringData);
            }
        }
    }

    private void AddDummyCharToLStringDummyCommands (char symbol, LStringData lStringData)
    {
        lStringData.LSystemDummyCommands.Add(symbol);
        Debug.Log("A dummy command has been added");
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
    public bool isADummyCommand;
}