using UnityEngine;

public class Spaceship : MonoBehaviour {
	public float speed; // 移動スピード
	public float shotDelay; // 弾を打つ間隔
	public GameObject bullet; // 弾のPrefab

	// 弾の作成
	public void Shot(Transform origin) {
		Instantiate(bullet, origin.position, origin.rotation);
	}
	// 機体の移動
	public void Move(Vector2 direction) {
		GetComponent<Rigidbody2D>().velocity = direction * speed;
	}
}
