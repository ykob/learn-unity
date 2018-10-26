using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour {

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
		Ray mouseRay = gameCamera.ScreenPointToRay(mouse);
		RaycastHit hit;

		Vector3 pos = gameCamera.ScreenToWorldPoint(mouse);
		floor.transform.position = pos;
	}
}
