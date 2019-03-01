using UnityEngine;
﻿using System.Collections;

public class Player : MonoBehaviour {
	// 移動スピード
	public float speed = 5;

	// PlayerBulletプレハブ
	public GameObject bullet;

	// Startメソッドをコルーチンとして呼び出す
	IEnumerator Start() {
		while(true) {
			// 弾をプレイヤーと同じ位置/確度で作成
			Instantiate (bullet, transform.position, transform.rotation);
			// 0.05秒待つ
			yield return new WaitForSeconds(0.05f);
		}
	}

	void Update() {
		float x = Input.GetAxisRaw("Horizontal");
		float y = Input.GetAxisRaw("Vertical");
		Vector2 direction = new Vector2(x, y).normalized;
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}
