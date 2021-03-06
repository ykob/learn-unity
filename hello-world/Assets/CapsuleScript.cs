﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CapsuleScript : MonoBehaviour {
  private float number;

	// Use this for initialization
	void Start () {
    number = 0f;
	}

	// Update is called once per frame
	void Update () {
		Transform myTransform = this.transform;
		Rigidbody myRigidbody = GetComponent<Rigidbody>();
    var numberText = GameObject.Find("NumberText").GetComponent<Text>();

		Vector3 pos = myTransform.position;
		if (pos.y < -20) {
			pos.x = 0;
			pos.y = 20;
			pos.z = 0;
			myTransform.position = pos;
			myRigidbody.velocity = new Vector3(0, number * -2f, 0);

      number = number + 1;
      numberText.text = number.ToString();
		}
	}
}
