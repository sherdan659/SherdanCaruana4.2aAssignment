using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float padding = 1f;
    float XMin;
    float XMax;
    float YMin;
    float YMax;


    // Start is called before the first frame update
    void Start()
    {
        ViewPortToWorldPoint();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime;
        var newX = transform.position.x + deltaX;
        transform.position = new Vector2(newX, transform.position.y);
        
    }

    private void ViewPortToWorldPoint()
    {
        Camera gameCamera = Camera.main;
        

        XMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        XMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;
        YMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        YMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;




    }
}
