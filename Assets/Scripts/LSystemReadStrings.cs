using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LSystemReadStrings : MonoBehaviour
{
    private static LSystemReadStrings _singleton;

    public static void ReadFinalString(LStringData lStringData)
    {
        
        RunTask( LoopThruStringAndInstantiate( lStringData ) );
    }

    private static void RunTask ( IEnumerator coroutine )
    {
        if ( _singleton == null )
        {
            var coroutineRunner = new GameObject ( "LString Reader" );
            _singleton = coroutineRunner.AddComponent<LSystemReadStrings>();
            coroutineRunner.hideFlags = HideFlags.HideInHierarchy;
            _singleton.StartCoroutine( coroutine );
        }
    }

    private static IEnumerator LoopThruStringAndInstantiate( LStringData lStringData )
    {
        Vector3 lastInstantiationLocation = Vector3.zero;

        string finalString = lStringData.LSystemStrings[
                lStringData.LSystemStrings.Count - 1];

        foreach (var c in finalString)
        {
            if (lStringData.LSystemCharToActionMap.ContainsKey(c))
            {
                switch ( lStringData.LSystemCharToActionMap[c] )
                {
                    case ActionType.MOVE_OBJECT:
                        Vector3 newInstantiationLocation = lastInstantiationLocation 
                            + Vector3.forward;
                        GameObject instantiatedPrefab = 
                        Instantiate(lStringData.prefabToSpawn, 
                            newInstantiationLocation, Quaternion.identity);
                            lastInstantiationLocation = newInstantiationLocation;
                        yield return scaleCylinder( instantiatedPrefab.transform, lStringData );
                        break;
                    default: 
                        yield return null;
                        break;
                }
            }
            else
            {
                yield return null;
            }
        }
    }

    private static IEnumerator scaleCylinder( Transform trans, LStringData lStringData )
    {
        Vector3 originalScale = trans.localScale;
        Vector3 targetScale = originalScale + 
            new Vector3(0, lStringData.GetLSystemSettings().defaultLength, 0);

        while ( trans.localScale.y < targetScale.y )
        {
            trans.localScale += new Vector3 (0, 0.1f, 0);
            yield return new WaitForSeconds(0.05f);
        }
    }

    public static void ReadAllStringActions()
    {
        // TODO... Implement same as ReadSpecificStringAction but reading through 
        // all LSystem strings
    }
}
