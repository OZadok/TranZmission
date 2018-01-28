using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HightComapreForPlayer : MonoBehaviour {

    public GameObject other;
    public float offset = -0.01f;
	
	// Update is called once per frame
	void Update () {
        this.transform.position = new Vector3(transform.position.x, other.transform.position.y + offset, transform.position.z);
	}
}
