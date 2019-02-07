using UnityEngine;
﻿using System.Collections;

public class GameController : MonoBehaviour {
	public UnityEngine.UI.Text scoreLabel;
	public void Update() {
		int count = GameObject.FindGameObjectsWithTag("Item").Length;
		scoreLabel.text = count.ToString();
	}
}
