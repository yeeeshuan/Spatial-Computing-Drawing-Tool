using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Raycast : MonoBehaviour
{
    Ray ray; 
    public int Id; 
    public GameObject Brush;
    private LineRenderer lr;
    // public LineRenderer draw; 
    
    private float redDist; 
    private float greenDist; 
    private float blueDist; 
    private Color color; 

    void Start()
    {
        lr = GetComponent<LineRenderer>(); 
        Id = 0; 
    }

    void Update()
    {
       CheckForColliders(); 
    }

    void CheckForColliders()
    {
        Vector3 forward = transform.TransformDirection(-transform.forward) * 10; 
        ray = new Ray(transform.position, forward); 
        RaycastHit hit;

        //for laser drawn 
        lr.SetPosition(0, transform.position); 

        Debug.DrawRay(transform.position, forward, Color.green);
        
        if (Physics.Raycast(ray, out hit))
        {
            Debug.Log("Hit"); 
            Debug.Log(hit.point);

            Debug.DrawRay(transform.position, hit.point, Color.red); 
            lr.SetPosition(1, hit.point);
            // draw.positionCount = draw.positionCount + 1; 
            // draw.SetPosition(draw.positionCount-1, hit.point); 

            GameObject obj = new GameObject();
            obj.AddComponent<LineRenderer>(); 

            LineRenderer draw = obj.GetComponent<LineRenderer>();
            draw.SetWidth(0f,0.1f);
            draw.SetPosition(0, hit.point); 
            draw.SetPosition(1, new Vector3(hit.point.x + 0.1f, hit.point.y + 0.1f, hit.point.z)); 

            redDist = Vector3.Distance(hit.point, new Vector3(3.0f, 0.53f, -8.00f));
            greenDist = Vector3.Distance(hit.point, new Vector3(1.5f, 0.53f, -8.00f));
            blueDist = Vector3.Distance(hit.point, new Vector3(0f, 0.53f, -8.00f));

            if (redDist < .5f)
            {
                color = Color.red; 
            }
            
            if (greenDist < .5f)
            {
                color = Color.green; 
            }

            if (blueDist < .5f)
            {
                color = Color.blue; 
            }

            draw.material.color = color; 

        }
        else
        { 
            lr.SetPosition(1, transform.position);
            Debug.Log("Not Hit");
        }

    }
}