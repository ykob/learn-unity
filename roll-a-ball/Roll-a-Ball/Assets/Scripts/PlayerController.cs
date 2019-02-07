using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	void FixedUpdate() {
		// 入力をxとzに代入
		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		// 同一のGameObjectが持つRigidbodyコンポーネントを取得
		Rigidbody rigidbody = GetComponent<Rigidbody>();

		// rigidbodyのx軸(横)とz軸(奥)に力を加える
		rigidbody.AddForce(x, 0, z);
	}
}
