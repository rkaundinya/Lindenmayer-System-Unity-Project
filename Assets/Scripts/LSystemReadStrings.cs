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

        string finalString = lStringData.LSystemStrings[
                lStringData.LSystemStrings.Count - 1];
        int numOfCharactersInFinalLString = finalString.Length;
        Vector3[] randomPositions = GenerateSetOfRandomNums ( 
                numOfCharactersInFinalLString , -20, 20);
        Vector3 lastPrefabLocationHighpoint = Vector3.zero;
        Quaternion angleToGrow = Quaternion.identity;
        ActionType lastActionType = ActionType.NoAction;

        int count = 0;

        foreach (var c in finalString)
        {
            if (lStringData.LSystemCharToActionMap.ContainsKey(c))
            {
                switch ( lStringData.LSystemCharToActionMap[c] )
                {
                    case ActionType.GROW_OBJECT:
                        // This code can be right after the if statement 
                        // once details of implementation is ironed out
                        /* Vector3 newInstantiationLocation = lastInstantiationLocation 
                            + Vector3.forward;
                        instantiatedPrefab = Instantiate(lStringData.prefabToSpawn, 
                        newInstantiationLocation, Quaternion.identity);
                        lastInstantiationLocation = newInstantiationLocation; */
                        if ( lastActionType == ActionType.ANGLE_OBJECT_POSITIVE || 
                            lastActionType == ActionType.ANGLE_OBJECT_NEGATIVE)
                        {
                            instantiatedPrefab = Instantiate( lStringData.prefabToSpawn, 
                                lastPrefabLocationHighpoint, angleToGrow );
                        }
                        else
                        {
                            angleToGrow = Quaternion.identity;

                            // Debug cube to highlight stored positions
                            /* GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                            cube.transform.position = lastPrefabLocationHighpoint; */

                            /* instantiatedPrefab = Instantiate( lStringData.prefabToSpawn, 
                                lastPrefabLocationHighpoint, angleToGrow ); */
                            instantiatedPrefab = Instantiate( lStringData.prefabToSpawn, 
                                randomPositions[count], angleToGrow );
                        }
                        lastPrefabLocationHighpoint = CalculateLastPositionHeight ( 
                                instantiatedPrefab, angleToGrow );
                        lastActionType = ActionType.GROW_OBJECT;
                        yield return scaleCylinder( instantiatedPrefab.transform, lStringData );
                        break;
                    case ActionType.ANGLE_OBJECT_POSITIVE:
                        // Debug sphere to highlight stored positions
                        /* GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                        sphere.transform.position = lastPrefabLocationHighpoint; */

                        lastPrefabLocationHighpoint = 
                                CalculateLastPositionHeight( instantiatedPrefab, angleToGrow );
                        angleToGrow = Quaternion.Euler( Mathf.Abs( 
                            lStringData.GetLSystemSettings().growthAngle ), 0, 0);
                        lastActionType = ActionType.ANGLE_OBJECT_POSITIVE;
                        break;
                    case ActionType.ANGLE_OBJECT_NEGATIVE:
                        lastPrefabLocationHighpoint = 
                            CalculateLastPositionHeight( instantiatedPrefab, angleToGrow );
                        angleToGrow = Quaternion.Euler( -Mathf.Abs( 
                            lStringData.GetLSystemSettings().growthAngle ), 0, 0);
                        lastActionType = ActionType.ANGLE_OBJECT_NEGATIVE;
                        break;
                    default: 
                        break;
                }
            }

            ++count;
        }

        yield return null;
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

    private static Vector3 CalculateLastPositionHeight( GameObject prefab, 
        Quaternion rotation )
    {
        Vector3 prefabStartingPosition = prefab.transform.position;
        Vector3 prefabLocalScale = prefab.transform.localScale;
        
        Vector3 directionVector = Vector3.zero;
        Vector3 highestPoint = Vector3.zero;

        if ( rotation == Quaternion.identity)
        {
            directionVector = Vector3.up;    
        }
        else
        {
            directionVector = rotation * Vector3.up;
        }

        highestPoint = prefabStartingPosition + 
            ( 2 * prefabLocalScale.y ) * directionVector;
        
        return highestPoint;
    }

    private static Vector3[] GenerateSetOfRandomNums( int numOfItems, 
        int minValue, int maxValue )
    {
        HashSet<Vector3> randomValuesHash = new HashSet<Vector3>();
        
        while ( randomValuesHash.Count < numOfItems )
        {  
            randomValuesHash.Add( new Vector3 ( Random.Range( minValue, maxValue ), 0f, 
                Random.Range( minValue, maxValue ) ) );
        }

        Vector3[] randomValuesArray = new Vector3[ numOfItems ];

        randomValuesHash.CopyTo( randomValuesArray, 0 );

        return randomValuesArray;
    }
}
