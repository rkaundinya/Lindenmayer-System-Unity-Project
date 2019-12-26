using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class testing4 : MonoBehaviour
{
    public abstract void DoWork3();
}

public abstract class testing : testing4
{
    private float value = 2; 

    public float value2 = 3; 

    public abstract void DoWork();
}

public interface testing3
{
    void DoWork2();
}

public interface testing2 : testing3
{
    void DoWork();
}

public class TestScript : testing
{
    private static TestScript _singleton;

    /* public void DoWork()
    {
        Debug.Log("DoWork from testing 2");
    }

    public void DoWork2()
    {
        Debug.Log("DoWork from testing 3");
    } */
    public override void DoWork()
    {} 

    public override void DoWork3()
    {}

    private void Start() 
    {
        RunTask( LoopSpawnAndScale() ); 
    }

    private static void RunTask ( IEnumerator coroutine )
    {
        if ( _singleton == null )
        {
            var testCoroutineRunner = new GameObject ( "Run-time Invoked Coroutine" );
            _singleton = testCoroutineRunner.AddComponent<TestScript>();
            // testCoroutineRunner.hideFlags = HideFlags.HideInHierarchy;
            _singleton.StartCoroutine( coroutine );
        }
    }

    private static IEnumerator LoopSpawnAndScale()
    {
        foreach (var character in "hello")
        {
            var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            yield return ScaleCubeToFive(cube);
            Debug.Log("Finished scale for char " + character);
        }
    }

    private static IEnumerator ScaleCubeToFive(GameObject cube)
    {
        while ( cube.transform.localScale.y < 6 )
        {
            cube.transform.localScale += new Vector3( 0, 0.1f, 0 );
            yield return new WaitForSeconds(0.05f);
        }
    }

    testing4 testObject; 
}