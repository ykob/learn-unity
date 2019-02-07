using UnityEngine;
﻿using System.Collections;

public class Item : MonoBehaviour {
	// トリガーとの接触時に呼ばれるコールバック
	void OnTriggerEnter (Collider hit) {
		if (hit.CompareTag ("Player")) {
			Destroy(gameObject);
		}
	}
}
