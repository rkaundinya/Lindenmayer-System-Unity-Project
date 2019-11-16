using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LSystemGenerationRules
{
    public static void AddRuleToRuleMap(char symbolToReplace, 
        string stringToReplaceSymbolWith, LStringData lStringData)
    {
        lStringData.StringMutationRuleMap.Add(symbolToReplace, stringToReplaceSymbolWith);
    }

    public static string ReplaceChar(char toReplace, string replaceWith, 
        LStringData lStringData)
    {
        if (lStringData.StringMutationRuleMap.ContainsKey(toReplace))
        {
            return replaceWith;
        }
        else
        {
            return toReplace.ToString();
        }
    }
}