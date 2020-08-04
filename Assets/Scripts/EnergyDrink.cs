﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyDrink : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null && player.maxRewindTime > player.rewindTime && !player.infiniteRewind)
        {
            player.ResetRewindTime();
            FindObjectOfType<AudioManager>().Play("Energy Drink");
            Destroy(gameObject);
        }
    }
}
