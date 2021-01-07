using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float playerHealth = 50;
    [SerializeField] float MovementSpeed = 5f;
    [SerializeField] float padding = 0f;
    float XMin;
    float XMax;



    // Start is called before the first frame update
    void Start()
    {
        ViewPortToWorldPoint();
    }

    // Update is called once per frame
    void Update()
    {
        //continuously plays the move method allowing movment of the player
        Move();
        //This continuesly prints the players health
        print(playerHealth);
    }

    private void ViewPortToWorldPoint()
    {
        Camera gameCamera = Camera.main;


        XMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        XMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;


    }
    private void Move() //Method to Player Car
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * MovementSpeed;//movement is horizontal

        var newXposition = Mathf.Clamp(transform.position.x + deltaX, XMin, XMax); //newXposition is the current position + the new position

        this.transform.position = new Vector2(newXposition, transform.position.y); //moving the car. Y remains the same, it doesn't need to move.
    }

    //Health
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Accesses damage dealer which will cause health reduction.

        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        playerHealth -= damageDealer.GetDamage();
        //destroys the bullit when it hits the car
        damageDealer.Hit();

        if (playerHealth <= 0)
        {
            Destroy(gameObject);
        }
    }


}
