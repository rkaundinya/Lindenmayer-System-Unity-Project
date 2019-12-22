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

    testing4 testObject; 
}