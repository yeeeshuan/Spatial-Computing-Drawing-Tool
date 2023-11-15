using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceSize : MonoBehaviour
{
    // Variable Declaration
    public GameObject Object1; //Reference RigidBody 1
    public GameObject Object2; //Reference RigidBody 2

    public float dist; //Float storing the distance between two objects
    public bool pState; //Previous State (video playing y/n)

    public float oScaleMultiplier = 1; //Original Scale Multiplier
    public float tScaleMultiplier = 2; //Target Scale Multiplier

    // Start is called before the first frame update
    void Start()
    {
        pState = false;
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(Object1.transform.position, Object2.transform.position);

        // If statement check
        if (dist < 1) //Change this Distance
        {
            //Check against previous state
            if (!pState)
            {
                //Only trigger if not previously playing
                Object1.transform.localScale = new Vector3(oScaleMultiplier,oScaleMultiplier,oScaleMultiplier);
            }
            pState = true; //Update previous state
        }
        else if (dist >= 1)
        {
            //Check against previous state
            if (pState)
            {
                //Only trigger if video is playing
                Object1.transform.localScale = new Vector3(tScaleMultiplier,tScaleMultiplier,tScaleMultiplier);
            }
            pState = false; //Update previous state
        }
    }
}
