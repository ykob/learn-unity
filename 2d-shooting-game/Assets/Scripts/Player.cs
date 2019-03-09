using UnityEngine;
﻿using System.Collections;

public class Player : Spaceship {
	// Startメソッドをコルーチンとして呼び出す
	IEnumerator Start() {
		while (true) {
			// 弾をプレイヤーと同じ位置/確度で作成
			Shot(transform);
			// ショット音を鳴らす
			GetComponent<AudioSource>().Play();
			// shotDelay秒待つ
			yield return new WaitForSeconds(shotDelay);
		}
	}

	void Update() {
		float x = Input.GetAxisRaw("Horizontal"); // 右・左
		float y = Input.GetAxisRaw("Vertical"); // 上・下

		// 移動する向きを求める
		Vector2 direction = new Vector2(x, y).normalized;
		// 移動
		Move(direction);
	}

	// 機体の移動
	protected override void Move(Vector2 direction) {
		// 画面左下のワールド座標をビューポートから取得
		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

		// 画面右上のワールド座標をビューポートから取得
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

		// プレイヤーの座標を取得
		Vector2 pos = transform.position;

		// 移動量を加える
		pos += direction * speed * Time.deltaTime;

		// プレイヤーの位置が画面内に収まるように制限をかける
		pos.x = Mathf.Clamp(pos.x, min.x, max.x);
		pos.y = Mathf.Clamp(pos.y, min.y, max.y);

		// 制限をかけた値をプレイヤーの位置とする
		transform.position = pos;
	}

	// ぶつかった瞬間に呼び出される
	void OnTriggerEnter2D(Collider2D c) {
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		// レイヤー名がBullet (Enemy)の時は弾を削除
		if (layerName == "Bullet (Enemy)") {
			// 弾の削除
			Destroy(c.gameObject);
		}

		// レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
		if (layerName == "Bullet (Enemy)" || layerName == "Enemy") {
			// Managerコンポーネントをシーン内から探して取得し、GameOverメソッドを呼び出す
			FindObjectOfType<Manager>().GameOver();

			// 爆発する
			Explosion();

			// プレイヤーを削除
			Destroy(gameObject);
		}
	}
}
