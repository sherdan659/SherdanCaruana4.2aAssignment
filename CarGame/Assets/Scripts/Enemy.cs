﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] float enemyLaserSpeed = 2f;
    [SerializeField] GameObject enemyLaserPrefab;


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
        //every frame reduces the amount of time that the frame takes to run
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            EnemyFire();
            //reset shotCounter after every fire
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    
    }

    private void EnemyFire()
    {

        GameObject enemyLaser = Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity) as GameObject;
        //enemy laser shoots downwards, hence -enemyLaserSpeed
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);
    }

}
