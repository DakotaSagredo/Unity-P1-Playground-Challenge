using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndTrigger : MonoBehaviour {

	private int playersAtEnd = 0;
	[SerializeField] private string loadLevel;

	void OnTriggerEnter (Collider col) { // Find type of collider, then begin 
		if (col.CompareTag ("Player1")) {
			playersAtEnd++;
			if (playersAtEnd == 2) {
				SceneManager.LoadSceneAsync (loadLevel);
			}
		}
		if (col.CompareTag ("Player2")) {
			playersAtEnd++;
			if (playersAtEnd == 2) {
				SceneManager.LoadSceneAsync (loadLevel);
			}
		}
	}
}