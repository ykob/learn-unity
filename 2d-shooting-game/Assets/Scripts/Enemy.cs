using UnityEngine;
﻿using System.Collections;

public class Enemy : MonoBehaviour {
	Spaceship spaceship; // Spaceshipコンポーネント

	IEnumerator Start() {
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship>();

		// ローカル座標のY軸のマイナス方向に移動する
		spaceship.Move(transform.up * -1);

		while(true) {
			// 子要素をすべて取得する
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild(i);

				// ShotPositionの位置/角度で弾を撃つ
				spaceship.Shot(shotPosition);
			}

			// shotDelay秒待つ
			yield return new WaitForSeconds(spaceship.shotDelay);
		}
	}
	void Update() {

	}
}
