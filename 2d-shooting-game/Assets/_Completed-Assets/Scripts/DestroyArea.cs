using UnityEngine;

namespace CompletedAssets
{
	public class DestroyArea : MonoBehaviour
	{
		void OnTriggerExit2D (Collider2D c)
		{
			Destroy (c.gameObject);
		}
	}
}