﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float bullietSpeed = 2f;
    [SerializeField] GameObject enemybulletPrefab;
    [SerializeField] public static int scoreValue = 50;


    // Start is called before the first frame update
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update()
    {
        CountDownAndShoot();
    }
    private void CountDownAndShoot()
    {

        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            EnemyFire();

            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }

    }

    private void EnemyFire()
    {
        //if statment that to check if object will fire bulliet
        if (enemybulletPrefab != null)
        {
            GameObject enemybullet = Instantiate(enemybulletPrefab, transform.position, Quaternion.identity) as GameObject;
            //-bullietspeed shoots downwards  
            enemybullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -bullietSpeed);
        }

    }






}