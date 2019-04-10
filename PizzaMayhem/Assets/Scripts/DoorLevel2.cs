﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorLevel2 : MonoBehaviour
{
    public AudioSource source;

    public void LoadByIndex(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        source.Play();
        if (coll.gameObject.tag == "Player")
        {
            LoadByIndex(3);
            PizzaBoyController boy = coll.GetComponent<PizzaBoyController>();
            boy.SavePlayer();
            //boy.SaveAmmo();
           // AmmoItem ammo = coll.GetComponent<AmmoItem>();
            //ammo.SaveAmmo();
        }    
            
        
    }
}
