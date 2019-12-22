using System;
using UnityEngine;

[Serializable]
public struct RuleMap
{
    public char charToMutate;
    public string stringToMutateTo;
    public bool isADummyCommand;
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
}