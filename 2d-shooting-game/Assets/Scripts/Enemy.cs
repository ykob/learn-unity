using UnityEngine;
﻿using System.Collections;

public class Enemy : Spaceship {
	IEnumerator Start() {
		// ローカル座標のY軸のマイナス方向に移動する
		Move(transform.up * -1);

		if (canShot == false) {
			yield break;
		}

		while(true) {
			// 子要素をすべて取得する
			for (int i = 0; i < transform.childCount; i++) {
				Transform shotPosition = transform.GetChild(i);

				// ShotPositionの位置/角度で弾を撃つ
				Shot(shotPosition);
			}

			//shotDelay秒待つ
			yield return new WaitForSeconds(shotDelay);
		}
	}

	protected override void Move(Vector2 direction) {
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}

	void OnTriggerEnter2D(Collider2D c) {
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		// レイヤー名がBullet (Player)以外の時は何も行わない
		if (layerName != "Bullet (Player)") return;

		// 弾の削除
		Destroy(c.gameObject);

		// 爆発
		Explosion();

		// エネミーの削除
		Destroy(gameObject);
	}
}
