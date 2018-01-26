using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void Update()
    {
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
}
