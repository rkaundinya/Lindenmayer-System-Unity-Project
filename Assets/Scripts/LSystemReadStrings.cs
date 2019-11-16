using System.Collections.Generic;
using UnityEngine;

public class LSystemReadStrings : MonoBehaviour
{
    public static void ReadSpecificStringAction(List<string> lStrings, 
        GameObject invokingObject, LStringData lStringData)
    {
        foreach (var lString in lStrings)
        {
            foreach (var c in lString)
                if (lStringData.LSystemCharToActionMap.ContainsKey(c))
                {
                    lStringData.LSystemCharToActionMap[c].DynamicInvoke(invokingObject);
                }
        }
    }

    public static void ReadAllStringActions()
    {
        // TODO... Implement same as ReadSpecificStringAction but reading through 
        // all LSystem strings
    }
}
