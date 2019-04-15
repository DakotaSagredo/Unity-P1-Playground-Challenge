using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachPlayer : MonoBehaviour {

	[SerializeField] private GameObject Player1;
	[SerializeField] private GameObject Player2;

	// For when the player moves onto a moving floor, they will move with it
	private void OnTriggerEnter(Collider col) {
		if (col.gameObject == Player1) {
			Player1.transform.parent = transform;
		}
		if (col.gameObject == Player2) {
			Player2.transform.parent = transform;
		}
	}

	// For when the player leaves the moving floor, they'll stop moving with it
	private void OnTriggerExit(Collider col) {
		if (col.gameObject == Player1) {
			Player1.transform.parent = null;
		}
		if (col.gameObject == Player2) {
			Player2.transform.parent = null;
		}
	}
}
