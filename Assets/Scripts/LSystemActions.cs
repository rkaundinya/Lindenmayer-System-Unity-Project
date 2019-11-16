using UnityEngine;

public class LSystemActions : MonoBehaviour
{
    public static void TestFunc2(GameObject gameObject)
    {
        gameObject.transform.position += Vector3.forward * 10;
    }
}