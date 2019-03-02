using UnityEngine;
﻿using System.Collections;

public class Player : MonoBehaviour {
	Spaceship spaceship; // Spaceshipコンポーネント

	// Startメソッドをコルーチンとして呼び出す
	IEnumerator Start() {
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship>();

		while(true) {
			// 弾をプレイヤーと同じ位置/確度で作成
			spaceship.Shot(transform);
			// shotDelay秒待つ
			yield return new WaitForSeconds(spaceship.shotDelay);
		}
	}

	void Update() {
		float x = Input.GetAxisRaw("Horizontal"); // 右・左
		float y = Input.GetAxisRaw("Vertical"); // 上・下

		// 移動する向きを求める
		Vector2 direction = new Vector2(x, y).normalized;
		// 移動
		spaceship.Move(direction);
	}
}
