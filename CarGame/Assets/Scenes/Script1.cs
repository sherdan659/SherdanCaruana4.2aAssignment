using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Script1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Bondaires();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Bondaires()
    {
        float xMin;
        float xMax;
        float yMin;
        float yMax;

        Camera camera = Camera.main;

        xMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = camera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = camera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = camera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

    }
}
