using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    Color[] colors;
    Renderer thisRend; //Cube Renderer
    float transitionTime = 5f; //Amount of time it takes to transition between colors
    
    // Start is called before the first frame update
    void Start()
    {
        thisRend = GetComponent<Renderer>();
        colors = new Color[6];
        colors[0] = Color.white;
        colors[1] = Color.black;
        colors[2] = Color.blue;
        colors[3] = Color.red;
        colors[4] = Color.green;
        colors[5] = Color.magenta;
        StartCoroutine(ColorChange());
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("newColor");
    }

    IEnumerator ColorChange() 
    {
        while (true)
        {
            Color newColor = colors[(Random.Range(0,5))];
            float transitionRate = 0;

            while (transitionRate < 1) {
                thisRend.material.SetColor("_Color", Color.Lerp(thisRend.material.color, newColor, Time.deltaTime * transitionRate));
                transitionRate += Time.deltaTime / transitionTime;
                yield return null;
            }
            yield return null;
        }
    }
}
