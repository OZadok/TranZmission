using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    private float health = 100;

    private float agility_attack_speed = 100f / 3f;
    private float cunning_visability = 100f / 3f;
    private float strength_damage = 100f / 3f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        movement();

    }

    private void movement()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h != 0 | v != 0)
        {
            float direction = Mathf.Atan2(v, h);
            float dx = Mathf.Cos(direction) / 10;
            float dy = Mathf.Sin(direction) / 10;
            this.transform.position = this.transform.position + new Vector3(dx, 0, dy);
        }
        
    }

    public void getHit(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            dead();
        }
    }

    private void dead()
    {
        //TODO

        Destroy(gameObject);
    }



    public float get_agility_attack_speed() { return agility_attack_speed; }
    public void set_agility_attack_speed(float agility_attack_speed) { this.agility_attack_speed = agility_attack_speed; }
    public float get_cunning_visability() { return cunning_visability; }
    public void set_cunning_visability(float cunning_damage) { this.cunning_visability = cunning_damage; }
    public float get_strength_damage() { return strength_damage; }
    public void set_strength_damage(float strength_visability) { this.strength_damage = strength_visability; }


}
