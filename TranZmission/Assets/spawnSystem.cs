﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnSystem : MonoBehaviour {


    public GameObject zombie;
    public GameObject player;
    private float last_spawn_time = 0;

    private const float spawn_time = 10;

    private const int max_zombie_amount = 50;
	
    // Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        float time = Time.timeSinceLevelLoad;
        if (last_spawn_time + spawn_time < time & transform.childCount < max_zombie_amount)
        {
            last_spawn_time = time;
            float spawn_rate = time / 4f + 8f * Mathf.Sin((time / 8f)) + 6;
            for (int i = 0; i < spawn_rate; ++i)
            {
                spawnSingleZombie();
            }
        }
        

        
    }

    private void spawnSingleZombie()
    {
        float x, y, z;
        float rnd_rad = Random.Range(0, 2*Mathf.PI);
        
        x = Mathf.Cos(rnd_rad);
        z = Mathf.Sin(rnd_rad);

        Vector3 position = player.transform.position + new Vector3(x, 0, z) * 40f;

        GameObject zombie_go = Instantiate(zombie, position, Quaternion.Euler(0, 0, 0)) as GameObject;
        zombie_go.transform.SetParent(transform);
        zombie_go.GetComponent<ZombieBehavior>().player = player;
    }
}
