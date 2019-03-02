using UnityEngine;
﻿using System.Collections;

public class Enemy : MonoBehaviour {
	Spaceship spaceship; // Spaceshipコンポーネント

	void Start() {
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship>();

		// ローカル座標のY軸のマイナス方向に移動する
		spaceship.Move(transform.up * -1);
	}
	void Update() {

	}
}
