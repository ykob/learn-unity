using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public abstract class Spaceship : MonoBehaviour {
	public float speed; // 移動スピード
	public float shotDelay; // 弾を打つ間隔
	public GameObject bullet; // 弾のPrefab
	public bool canShot; // 弾を撃つかどうか
	public GameObject explosion; // 爆発のPrefab
	private Animator animator; // アニメーターコンポーネント

	public void Start() {
		//アニメーターコンポーネントを取得
		animator = GetComponent<Animator>();
	}
	// 爆発の作成
	public void Explosion() {
		Instantiate(explosion, transform.position, transform.rotation);
	}
	// 弾の作成
	public void Shot(Transform origin) {
		Instantiate(bullet, origin.position, origin.rotation);
	}
	// アニメーターコンポーネントの取得
	public Animator GetAnimator() {
		return animator;
	}

	protected abstract void Move (Vector2 direction);
}
