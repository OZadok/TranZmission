using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

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
            float dx = Mathf.Cos(direction) / 100;
            float dy = Mathf.Sin(direction) / 100;
            this.transform.position = this.transform.position + new Vector3(dx, dy, 0);
        }
        
    }
}
