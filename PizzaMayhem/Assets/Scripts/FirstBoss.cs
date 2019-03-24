﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FirstBoss : MonoBehaviour
{
    public float speed = 10f;
    public float stoppingDistance;
    public float retreatDistance;
    private float timeBetShots;
    public float startTimeBetShots;
    private Transform player;
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if(Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if(Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if(timeBetShots <= 0)
        {
            Vector2 bulletrotate = transform.position-player.position; 
            //Bullet1.Rotate(bulletrotate,Space.World);
            //Instantiate(projectile, transform.position, Quaternion.identity);
            Quaternion bulletangle = new Quaternion();
            bulletangle.Set(bulletrotate.x, bulletrotate.y, 0, 0);
            
            
            //bulletrotate.y=bulletrotate.y+ Mathf.Cos((45 * Mathf.PI) / 180) * 1;
            //bulletrotate.x=bulletrotate.x+ Mathf.Cos((45 * Mathf.PI) / 180) * 1;
            Instantiate(projectile, transform.position, bulletangle);
            //FireAtPlayer();
            timeBetShots = startTimeBetShots;
        }
        else
        {
            timeBetShots -= Time.deltaTime;
        }
    }
    public int health = 100;

    public void Damage(int damageVal)
    {
        health = health - damageVal;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void FireAtPlayer()
    {
        Instantiate(projectile);
        projectile.transform.position = transform.position;
        Vector2 direction = player.position - projectile.transform.position;
        direction.Normalize();
       // direction
        //direction.Set(direction.x +  2, direction.y +  2));
        projectile.GetComponent<Rigidbody2D>().velocity =
                direction;
    }

}
