using UnityEngine;

namespace CompletedAssets
{
	public class Explosion : MonoBehaviour
	{
		void OnAnimationFinish ()
		{
			Destroy (gameObject);
		}
	}
}