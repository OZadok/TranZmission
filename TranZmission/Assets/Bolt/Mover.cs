using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {

    private const float max_distance_from_start = 20;

    private Vector3 start_location;

    private float damage = 20;

    private GameObject player;

    void Start()
    {
        float speed = 50 * player.GetComponent<PlayerBehavior>().get_agility_attack_speed() / 100;
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        start_location = transform.position;
        damage = damage * player.GetComponent<PlayerBehavior>().get_strength_damage() / 100 ;
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

    public void setPlayer(GameObject player)
    {
        this.player = player;
    }

    

}
