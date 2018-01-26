﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class ZombieBehavior : MonoBehaviour {

    public SpriteRenderer zombie_sprite;

    private Vector3 target_position;
    private NavMeshAgent agent;

    private float agility = 0;
    private float cunning = 0;
    private float aggressiveness = 0;

    private const float max_properties_level = 100;
    private const float start_property_level = 80;
    public int start_property_index = 0;

    private float direction;
    private float random_direction;
    private Vector3 random_position;
    private const float cunning_radius = 10;
    private const float cunning_direct_radius = 5;
    private const int min_direction_change_time = 1;
    private const int max_direction_change_time = 5;
    private float time_to_change_direction = 0;

    private const float speed_addition = 1;
    private const float speed_correction_divisor = 200;

    private const int zombie_transmission_max_distance = 5;
    private const int transfer_amount = 1;
    private float time_to_transmit = 0;
    private const float min_delta_time_to_transmit = 1;
    private const float max_delta_time_to_transmit = 5;

    private int health = 100;


    private void initProperties()
    {
        int dominant_property = Random.Range(0, 3);
        float dominant_property_level = Random.Range(start_property_level, max_properties_level);
        float second = Random.Range(0, max_properties_level - dominant_property_level);
        float third = max_properties_level - (second + dominant_property_level);
        switch (dominant_property)
        {
            case 0:
                agility = dominant_property_level;
                cunning = second;
                aggressiveness = third;
                break;
            case 1:
                cunning = dominant_property_level;
                aggressiveness = second;
                agility = third;
                break;
            case 2:
                aggressiveness = dominant_property_level;
                agility = second;
                cunning = third;
                break;
        }

    }

    // Use this for initialization
    void Start () {
        agent = GetComponent<NavMeshAgent>();
        
        initProperties();
    }

    

    private void updatePosition()
    {
        Vector3 previous_target_position = target_position;
        if (Time.timeSinceLevelLoad > time_to_change_direction)
        {
            time_to_change_direction = Time.timeSinceLevelLoad + Random.Range(min_direction_change_time, max_direction_change_time);
            float rnd_x = Random.Range(-2, 2);
            float rnd_z = Random.Range(-2, 2);
            random_position = this.gameObject.transform.position + new Vector3(rnd_x, 0, rnd_z);
        }

        target_position = random_position;


        Vector3 delta = GameObject.FindGameObjectWithTag("Player").transform.position - this.transform.position;
        if (delta.magnitude < cunning_direct_radius)
        {
            target_position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        else if (delta.magnitude < cunning_radius)
        {
            Vector3 player_position = GameObject.FindGameObjectWithTag("Player").transform.position;
            float px = player_position.x * (cunning / max_properties_level) + target_position.x * (1 - cunning / max_properties_level);
            float py = player_position.y * (cunning / max_properties_level) + target_position.y * (1 - cunning / max_properties_level);
            float pz = player_position.z * (cunning / max_properties_level) + target_position.z * (1 - cunning / max_properties_level);
            target_position = new Vector3(px, py, pz);
        }

        
        agent.SetDestination(target_position);
        //transform.rotation = Quaternion.Euler(0, 0, 0);

        if (target_position.x != transform.position.x)
        {
            zombie_sprite.flipX = target_position.x < transform.position.x;
        }
    }
	
	// Update is called once per frame
	void Update () {
        updatePosition();
    }

    private void FixedUpdate()
    {
        //setNewDirection();
        updatePosition();
        propertiesAcquisition();
    }


    private void propertiesAcquisition()
    {
        if (Time.timeSinceLevelLoad > time_to_transmit)
        {
            time_to_transmit = Time.timeSinceLevelLoad + Random.Range(min_delta_time_to_transmit, max_delta_time_to_transmit);
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie").OrderBy(go => (go.transform.position - transform.position).magnitude).ToArray();
            foreach (GameObject zombie in zombies)
            {
                if ((zombie.transform.position - transform.position).magnitude > zombie_transmission_max_distance)
                {
                    break;
                }
                ZombieBehavior other_zombie_behavior = zombie.GetComponent<ZombieBehavior>();
                if (other_zombie_behavior.agility > agility)
                {
                    other_zombie_behavior.agility -= transfer_amount;
                    agility += transfer_amount;
                }

                if (other_zombie_behavior.cunning > cunning)
                {
                    other_zombie_behavior.cunning -= transfer_amount;
                    cunning += transfer_amount;
                }

                if (other_zombie_behavior.aggressiveness > aggressiveness)
                {
                    other_zombie_behavior.aggressiveness -= transfer_amount;
                    aggressiveness += transfer_amount;
                }

            }

        }
    }

    public void getHit(int damage)
    {
        health -= damage;
    }
}
