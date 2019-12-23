using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderGrowth : MonoBehaviour
{
    /* // Start is called before the first frame update
    void Start()
    {
        GameObject cylinder = CylinderSingleSideGrowth.
            CreatePrimitive(CylinderSingleSideGrowth.CylinderPivotPoint.RIGHT);

        StartCoroutine(scaleCylinder(cylinder.transform));
    } */

    private void Start() 
    {
        // StartCoroutine( scaleCylinder( this.transform ) );    
    }

    IEnumerator scaleCylinder( Transform trans )
    {
        while (true)
        {
            trans.localScale += new Vector3( 0, 0.1f, 0 );
            yield return null;
        }
    }
}
