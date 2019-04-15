using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

	// SerializedField creates a data field to appear on Unity, while still
	// keeping the variable private, so it can't be accessed elsewhere
	[SerializeField] private Transform player1;
	[SerializeField] private Transform player2;
	[SerializeField] private Transform respawnPoint;

	// When player touches collider, teleport player to respawn point
	void OnTriggerEnter(Collider col) {
		if (col.CompareTag("Player1")) { // If player1 touches deathzone, respawn
			player1.transform.position = respawnPoint.transform.position;
		}
		else if (col.CompareTag("Player2")) { // If player2 touches deathzone, respawn
			player2.transform.position = respawnPoint.transform.position;
		}
	}
}
