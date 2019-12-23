using System;
using UnityEngine;

[Serializable]
public struct RuleMap
{
    public char charToMutate;
    public string stringToMutateTo;
    public bool isADummyCommand;
    public ActionType actionType;
}

[Serializable]
public struct LSystemSettings
{
    public string axiom;
    public float defaultAngle; 
    public float defaultLength;
    public float defaultGrowthSpeed;
    [Range(0.0f, 100.0f)]
    public float angleRandomness;
    [Range(0.0f, 100.0f)]
    public float lengthRandomness;
    [Range(0.0f, 100.0f)]
    public float growthSpeedRandomness;
    public int totalNumOfMutations;

    public void ResetData()
    {
        axiom = null;
        defaultAngle = 0f;
        defaultLength = 0f;
        defaultGrowthSpeed = 0f;
        angleRandomness = 0f;
        lengthRandomness = 0f;
        growthSpeedRandomness = 0f;
        totalNumOfMutations = 1;
    }
}