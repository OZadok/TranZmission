using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayeringEnvironment : MonoBehaviour {

	
	void Start () {
        this.transform.position = new Vector3(transform.position.x, -transform.position.z, transform.position.z);
	}
}
