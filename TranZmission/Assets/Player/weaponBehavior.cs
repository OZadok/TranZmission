using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponBehavior : MonoBehaviour {

    public Transform pivot_transform;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;

    private float nextFire;


    public Animator gun_anim;
    

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        float h = Input.GetAxis("WeaponHorizontal");
        float v = Input.GetAxis("WeaponVertical");

        if (h != 0 || v != 0)
        {
            float direction = Mathf.Atan2(h, v);
            pivot_transform.rotation = Quaternion.Euler(0, direction * Mathf.Rad2Deg, 0);
        }


        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject bulet = Instantiate(shot, shotSpawn.position, shotSpawn.rotation) as GameObject;
            bulet.GetComponent<Mover>().setPlayer(gameObject.transform.parent.parent.gameObject);

            gun_anim.SetTrigger("isShot");
        }

    }


}
