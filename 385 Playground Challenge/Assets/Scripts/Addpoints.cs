using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addpoints : MonoBehaviour {
	
	private void OnTriggerEnter (Collider col) { // When the player touches a coin
		if (col.CompareTag("Player1") || col.CompareTag("Player2"))
		col.GetComponent<EndLevel2>().points++; // Add 1 to points in the EndLevel2 script
	}
}