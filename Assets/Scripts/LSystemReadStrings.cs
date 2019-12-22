using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemReadStrings : MonoBehaviour
{
    public static void ReadSpecificStringAction(LStringData lStringData)
    {
        foreach (var lString in lStringData.LSystemStrings)
        {
            Debug.Log("The current string is " + lStringData.LSystemStrings);
            foreach (var c in lString)
            {
                if (lStringData.LSystemCharToActionMap.ContainsKey(c))
                {
                    if (lStringData.LSystemCharToActionMap[c] == ActionType.MOVE_OBJECT)
                    {
                        Instantiate(lStringData.prefabToSpawn, 
                            new Vector3 (0, 0, 0), Quaternion.identity);
                    }
                }
            }
        }
    }

    IEnumerator scaleCylinder( Transform trans )
    {
        while (true)
        {
            trans.localScale += new Vector3( 0, 0.1f, 0 );
            yield return null;
        }
    }

    public static void ReadAllStringActions()
    {
        // TODO... Implement same as ReadSpecificStringAction but reading through 
        // all LSystem strings
    }
}
