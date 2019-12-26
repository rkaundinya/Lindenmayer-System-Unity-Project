using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSingleSideGrowth
{
    public enum CylinderPivotPoint
    {
        MIDDLE, LEFT, RIGHT, UP, DOWN, FORWARD, BACK
    }

    //Takes CubePivotPoint Enum as pivot point
    public static GameObject CreatePrimitive(CylinderPivotPoint pivot)
    {
        //Calculate pivot point
        Vector3 cylinderPivot = createPivotPos(pivot);

        //Create cube with the calculated pivot point
        return createCylinderWithPivotPoint(cylinderPivot);
    }

    //Takes Vector3 as pivot point
    public static GameObject CreatePrimitive(Vector3 pivot)
    {
        //Create cube with the calculated pivot point
        return createCylinderWithPivotPoint(pivot);
    }

    private static Vector3 createPivotPos(CylinderPivotPoint pivot)
    {
        switch (pivot)
        {
            case CylinderPivotPoint.MIDDLE:
                return new Vector3(0f, 0f, 0f);
            case CylinderPivotPoint.LEFT:
                return new Vector3(-0.5f, 0f, 0f);
            case CylinderPivotPoint.RIGHT:
                return new Vector3(0.5f, 0f, 0f);
            case CylinderPivotPoint.UP:
                return new Vector3(0f, 1.0f, 0f);
            case CylinderPivotPoint.DOWN:
                return new Vector3(0f, -1.0f, 0f);
            case CylinderPivotPoint.FORWARD:
                return new Vector3(0f, 0f, 0.5f);
            case CylinderPivotPoint.BACK:
                return new Vector3(0f, 0f, -0.5f);
            default:
                return default(Vector3);
        }
    }

    private static GameObject createCylinderWithPivotPoint(Vector3 pivot)
    {
        //Create a cube postioned at 0,0,0
        GameObject childCylinder = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
        //Create an empty parent object
        GameObject parentObject = new GameObject("CylinderHolder");
        //Move the parent object to the provided pivot postion 
        parentObject.transform.position = pivot;
        //Make the childcube to be child child of the empty object (CubeHolder)
        childCylinder.transform.SetParent(parentObject.transform);
        return parentObject;
    }
}
