using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitFloorScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		Vector3 mouse = Input.mousePosition;
		GameObject floor = GameObject.Find("Floor");

		mouse.x = Mathf.Clamp(mouse.x, 0.0f, Screen.width);
		mouse.y = Mathf.Clamp(mouse.y, 0.0f, Screen.height);

		Camera gameCamera = Camera.main;
		Ray ray = gameCamera.ScreenPointToRay(mouse);
		RaycastHit hit;
		if (Physics.Raycast(ray, out hit)) {
			floor.transform.position = hit.point;
		}
	}
}
