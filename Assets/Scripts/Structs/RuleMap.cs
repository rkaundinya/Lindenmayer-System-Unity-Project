using System;
using UnityEngine;

[Serializable]
public struct RuleMap
{
    public char charToMutate;
    public string stringToMutateTo;

    [HideInInspector]
    public int choiceIndex;
    [HideInInspector]
    public string currentLetterChoice;
}