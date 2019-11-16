using UnityEngine;

public class LSystemActions : MonoBehaviour
{
    public static void TestFunc2(GameObject gameObject)
    {
        gameObject.transform.position += Vector3.forward * 10;
        Debug.Log("I'm working too");
    }
}

// TODO... I can't make LSystemActions methods static because making methods static
// means that all objects that use the method only have one impelementation of it. 
// So if I wanted to have several different LSystems at once on screen, they 
// can all only have the same behavior. Not what we want in the end!