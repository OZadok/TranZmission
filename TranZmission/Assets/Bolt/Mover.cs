using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private const float max_distance_from_start = 20;
    public float speed;

    private Vector3 start_location;

    private const int damage = 2;

    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        start_location = transform.position;
    }

    private void LateUpdate()
    {
        if ((transform.position - start_location).magnitude > max_distance_from_start)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Zombie")
        {
            other.GetComponent<ZombieBehavior>().getHit(damage);
            Destroy(gameObject);
        }
    }

}
