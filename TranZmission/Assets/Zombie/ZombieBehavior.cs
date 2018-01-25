using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour {


    private int agility = 0;
    private int cunning = 0;
    private int Aggressiveness = 0;

    private const int max_properties_level = 100;
    private const int start_property_level = 80;
    public int start_property_index = 0;

    private float direction;
    private float random_direction;
    private float cunning_radius = 5;
    private const int min_direction_change_time = 1;
    private const int max_direction_change_time = 5;
    private float time_to_change_direction = 0;


    private void initProperties()
    {
        int dominant_property = Random.Range(0, 3);
        int dominant_property_level = Random.Range(start_property_level, max_properties_level);
        int second = Random.Range(0, max_properties_level - dominant_property_level);
        int third = max_properties_level - second;
        switch (dominant_property)
        {
            case 0:
                agility = dominant_property_level;
                cunning = second;
                Aggressiveness = third;
                break;
            case 1:
                cunning = dominant_property_level;
                Aggressiveness = second;
                agility = third;
                break;
            case 2:
                Aggressiveness = dominant_property_level;
                agility = second;
                cunning = third;
                break;
        }

    }

    // Use this for initialization
    void Start () {
        initProperties();
        setNewDirection();
    }

    private void setNewDirection()
    {
        //TODO!!!
        float player_direction;
        if (Time.timeSinceLevelLoad > time_to_change_direction)
        {
            time_to_change_direction = Time.timeSinceLevelLoad + Random.Range(min_direction_change_time, max_direction_change_time);
            random_direction = Random.Range(0, Mathf.PI);
        }

        Vector3 delta = GameObject.FindGameObjectWithTag("Player").transform.position - this.transform.position;
        if (delta.magnitude < cunning_radius)
        {
            player_direction = Mathf.Atan2(delta.x, delta.y);
        }
        else
        {
            player_direction = direction;
        }
        

        
        


    }

    private void updatePosition()
    {
        float dx = Mathf.Cos(direction) / 200;
        float dy = Mathf.Sin(direction) / 200;
        this.transform.position = this.transform.position + new Vector3(dx, dy, 0);
    }
	
	// Update is called once per frame
	void Update () {
        updatePosition();
    }

    private void FixedUpdate()
    {
        setNewDirection();
    }
}
