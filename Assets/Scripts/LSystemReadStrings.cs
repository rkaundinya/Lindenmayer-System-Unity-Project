using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemReadStrings : MonoBehaviour
{
    public static void ReadSpecificStringAction(LStringData lStringData)
    {
        Vector3 lastInstantiationLocation = Vector3.zero;

        foreach (var lString in lStringData.LSystemStrings)
        {
            Debug.Log("The current string is " + lStringData.LSystemStrings);
            foreach (var c in lString)
            {
                if (lStringData.LSystemCharToActionMap.ContainsKey(c))
                {
                    if (lStringData.LSystemCharToActionMap[c] == ActionType.MOVE_OBJECT)
                    {
                        Vector3 newInstantiationLocation = lastInstantiationLocation 
                            + Vector3.forward;
                        Instantiate(lStringData.prefabToSpawn, 
                            newInstantiationLocation, Quaternion.identity);
                        lastInstantiationLocation = newInstantiationLocation;
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
