using System.Collections.Generic;
using UnityEngine;

public class LSystemReadStrings : MonoBehaviour
{
    public static void ReadSpecificStringAction(List<string> lStrings, 
        GameObject invokingObject, LStringData lStringData)
    {
        foreach (var lString in lStrings)
        {
            Debug.Log("The current string is " + lString);
            foreach (var c in lString)
                if (lStringData.LSystemCharToActionMap.ContainsKey(c))
                {
                    if (lStringData.LSystemCharToActionMap[c] != null)
                    {
                        // StartCoroutine(LSystemActions.MoveForward(invokingObject, 1f, 10f));
                        
                        // lStringData.LSystemCharToActionMap[c].DynamicInvoke(invokingObject, 1f, 10f);
                    }
                }
        }
    }

    public static void ReadAllStringActions()
    {
        // TODO... Implement same as ReadSpecificStringAction but reading through 
        // all LSystem strings
    }
}
