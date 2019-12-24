using System;
using UnityEngine;

[Serializable]
public struct LSystemSettings
{
    public string axiom;
    public float growthAngle; 
    public float growthLength;
    public float growthSpeed;
    [Range(0.0f, 100.0f)]
    public float angleRandomness;
    [Range(0.0f, 100.0f)]
    public float lengthRandomness;
    [Range(0.0f, 100.0f)]
    public float growthSpeedRandomness;
    public int totalNumOfMutations;

    public void ResetData()
    {
        axiom = null;
        growthAngle = 0f;
        growthLength = 0f;
        growthSpeed = 0f;
        angleRandomness = 0f;
        lengthRandomness = 0f;
        growthSpeedRandomness = 0f;
        totalNumOfMutations = 1;
    }
}