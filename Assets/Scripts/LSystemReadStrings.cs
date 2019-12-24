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
        GameObject instantiatedPrefab = lStringData.prefabToSpawn;
        Vector3 lastInstantiationLocation = Vector3.zero;
        // bool newInstantiationNeeded = false;
        string finalString = lStringData.LSystemStrings[
                lStringData.LSystemStrings.Count - 1];

        foreach (var c in finalString)
        {
            if (lStringData.LSystemCharToActionMap.ContainsKey(c))
            {
                switch ( lStringData.LSystemCharToActionMap[c] )
                {
                    case ActionType.GROW_OBJECT:
                        // This code can be right after the if statement 
                        // once details of implementation is ironed out
                        Vector3 newInstantiationLocation = lastInstantiationLocation 
                            + Vector3.forward;
                        instantiatedPrefab = Instantiate(lStringData.prefabToSpawn, 
                        newInstantiationLocation, Quaternion.identity);
                        lastInstantiationLocation = newInstantiationLocation;
                        yield return scaleCylinder( instantiatedPrefab.transform, lStringData );
                        break;
                    case ActionType.CHANGE_OBJECT_ANGLE:
                        Vector3 lastPrefabLocationHighpoint = 
                            CalculateLastPositionHeight( instantiatedPrefab );
                        Instantiate( lStringData.prefabToSpawn, lastPrefabLocationHighpoint, 
                            Quaternion.Euler( lStringData.GetLSystemSettings().growthAngle, 0, 0 ) );
                        break;
                        //instantiatedPrefab = Instantiate(lStringData.prefabToSpawn, )
                        //yield return 
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
            new Vector3(0, lStringData.GetLSystemSettings().growthLength, 0);

        while ( trans.localScale.y < targetScale.y )
        {
            trans.localScale += new Vector3 (0, 0.1f, 0);
            yield return new WaitForSeconds(0.05f);
        }

        yield return null;
    }

    private static Vector3 CalculateLastPositionHeight( GameObject prefab )
    {
        Vector3 prefabStartingPosition = prefab.transform.position;
        Vector3 prefabLocalScale = prefab.transform.localScale;
        Vector3 highestPoint = prefabStartingPosition + new Vector3 (0, 2 * prefabLocalScale.y, 0);
        return highestPoint;
    }
}
