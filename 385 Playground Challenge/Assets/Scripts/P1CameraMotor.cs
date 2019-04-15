using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1CameraMotor : MonoBehaviour {

	public GameObject target;
	public float xOffset, yOffset, zOffset; // Camera distance from object(marble)

	// Like Update(), LateUpdate() is called once per frame, but runs after all items have been processed
	void LateUpdate() {
		// target.transform.position sets the camera to be exactly in the target
		// + new Vector3(xOffset, yOffset, zOffset allows it to be away from the target
		transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset);
		transform.LookAt (target.transform.position); // Will make the camera look at the ball
	}
}
