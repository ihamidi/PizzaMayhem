﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int lives;
    public int ammo;

    public PlayerData(PizzaBoyController player)
    {
        lives = player.lives;
    }

    public PlayerData(Ammo ammoCount)
    {
        ammo = ammoCount.ammo;
    }
}
