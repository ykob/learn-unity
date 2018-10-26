using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Transform myTransform = this.transform;

		Vector3 pos = myTransform.position;
		if (pos.y < -20) {
			pos.x = 0;
			pos.y = 20;
			pos.z = 0;
			myTransform.position = pos;
		}
	}
}
