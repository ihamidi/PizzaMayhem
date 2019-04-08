﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLevel2 : MonoBehaviour
{
    public Scene scene;
    public void LoadByIndex(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.tag == "Player")
        {
            LoadByIndex(3);
            PizzaBoyController boy = coll.GetComponent<PizzaBoyController>();
            boy.SavePlayer();
            AmmoItem ammo = coll.GetComponent<AmmoItem>();
            ammo.SaveAmmo();
        }    
            
        
    }
}