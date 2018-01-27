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
        Application.LoadLevel(0);
        //Destroy(gameObject);
    }



    public float get_agility_attack_speed() { return agility_attack_speed; }
    public void set_agility_attack_speed(float agility_attack_speed) { this.agility_attack_speed = agility_attack_speed; }
    public float get_cunning_visability() { return cunning_visability; }
    public void set_cunning_visability(float cunning_damage) { this.cunning_visability = cunning_damage; }
    public float get_strength_damage() { return strength_damage; }
    public void set_strength_damage(float strength_visability) { this.strength_damage = strength_visability; }


}
