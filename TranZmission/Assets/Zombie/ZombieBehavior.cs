using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBehavior : MonoBehaviour {


    private int[] properties = new int[3];
    private const int start_property_level = 100;
    public int start_property_index = 0;

    private float direction;
    private const int min_direction_change_time = 1;
    private const int max_direction_change_time = 5;
    private float time_to_change_direction = 0;


    // Use this for initialization
    void Start () {
        properties[start_property_index] = start_property_level;
        setNewDirection();
    }

    private void setNewDirection()
    {
        if (Time.timeSinceLevelLoad > time_to_change_direction)
        {
            time_to_change_direction = Time.timeSinceLevelLoad + Random.Range(min_direction_change_time, max_direction_change_time);
            direction = Random.Range(0, Mathf.PI);
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
