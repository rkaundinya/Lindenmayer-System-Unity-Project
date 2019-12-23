using System.Collections;
using UnityEngine;

public class LSystemActions : MonoBehaviour
{
    public static void MoveForward(GameObject gameObject)
    {
        gameObject.transform.position += Vector3.forward * 2;
    }

    public static void MoveCube(GameObject gameObject, float speed, float journeyLength, float startTime, 
        Vector3 startPosition, Vector3 endPosition, bool movingCube)
    {
        // movementFinished = false;
        float distCovered = (Time.time - startTime) * speed;
        float fractionOfJourney = distCovered / journeyLength;
        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        if (fractionOfJourney >= 1)
        {
            movingCube = false;
        }
    }

    public static IEnumerator scaleCylinder( Transform trans, bool routineFinished )
    {
        routineFinished = false;
        yield return new WaitForSeconds(3f);
        Debug.Log("Coroutine finished after waiting 3 seconds");
        routineFinished = true;
        /* float endTime = Time.time + 3.0f;

        while (Time.time < endTime)
        {
            trans.localScale += new Vector3( 0, 0.1f, 0 );
            yield return null;
        } */
    }
    
    /* public static IEnumerator MoveForward(GameObject gameObject, float moveSpeed, 
        float growthDistance)
    {
        float distCovered = 0;
        float startTime = 0;
        Vector3 startPosition = Vector3.zero;
        Vector3 endPosition = Vector3.zero;

        if (distCovered == 0)
        {
            startTime = Time.time;
            startPosition = gameObject.transform.position;
            Vector3 endPosition = gameObject.transform.position + 
                (Vector3.forward * growthDistance);
        }

        while (distCovered < growthDistance)
        {
            distCovered = (Time.time - startTime) * moveSpeed;

            float fractionOfDistTraveled = distCovered / growthDistance;

            gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, 
                fractionOfDistTraveled);
        }

        yield return null;
    } */

    // public static void 
}