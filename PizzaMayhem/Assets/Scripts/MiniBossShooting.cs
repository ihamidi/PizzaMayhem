﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniBossShooting : MonoBehaviour
{

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
        FireAtPlayer();
    }
    void FireAtPlayer()
    {
        float angleStep = 360f / 5;
        float angle = 0f;
        Vector2 startPoint =transform.position;
        Quaternion bulletangle = new Quaternion();
        Vector2 bulletrotate = transform.position - player.position;
        bulletangle.Set(bulletrotate.x, bulletrotate.y, 0, 0);
        for (int i = 0; i <= 5 - 1; i++)
        {

            float projectileDirXposition = startPoint.x + Mathf.Sin((angle * Mathf.PI) / 180) * 1;
            float projectileDirYposition = startPoint.y + Mathf.Cos((angle * Mathf.PI) / 180) * 1;

            Vector2 projectileVector = new Vector2(projectileDirXposition, projectileDirYposition);
            Vector2 projectileMoveDirection = (projectileVector - startPoint).normalized;

            var proj = Instantiate(projectile, startPoint, bulletangle);
            proj.GetComponent<Rigidbody2D>().velocity =
                new Vector2(projectileMoveDirection.x, projectileMoveDirection.y);

            angle += angleStep;
        }
    }
}
