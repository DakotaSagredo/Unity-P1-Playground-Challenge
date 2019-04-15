using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel2 : MonoBehaviour {

	public int points = 0; // Points are sent from the Addpoints script
	[SerializeField] private string loadLevel;

	void OnTriggerEnter (Collider col) { // Find type of collider, then begin 
		if (col.CompareTag ("Player1")) {
			SceneManager.LoadSceneAsync (loadLevel);
		}
		if (col.CompareTag ("Player2")) {
			SceneManager.LoadSceneAsync (loadLevel);
		}
	}
}