using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceColor : MonoBehaviour
{
    // Variable Declaration
    public GameObject Object1; //Reference RigidBody 1
    public GameObject Object2; //Reference RigidBody 2

    public float dist; //Float storing the distance between two objects
    public bool pState; //Previous State (video playing y/n)

    Color[] colors1;
    Color newColor;
    Renderer obj1Rend;
    float transitionTime = 5000;
    float transitionStart;
    float transitionRate;

    // Start is called before the first frame update
    void Start()
    {
        obj1Rend = Object1.GetComponent<Renderer>();
        colors1 = new Color[2];
        colors1[0] = Color.magenta;
        colors1[1] = Color.blue;

        pState = false;
        newColor = colors1[0];
        transitionStart = 0f;
        transitionRate = 0f;
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
                newColor = colors1[0];
                transitionStart = Time.frameCount;
            }
            pState = true; //Update previous state
        }
        else if (dist >= 1)
        {
            //Check against previous state
            if (pState)
            {
                //Only trigger if video is playing
                newColor = colors1[1];
                transitionStart = Time.frameCount;
            }
            pState = false; //Update previous state
        }

        transitionRate = (Time.frameCount - transitionStart) / transitionTime;
        obj1Rend.material.SetColor("_Color", Color.Lerp(obj1Rend.material.color, newColor, transitionRate));
    }
}
