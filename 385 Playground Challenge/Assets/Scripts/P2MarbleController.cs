using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class P2MarbleController : MonoBehaviour {

	[FormerlySerializedAs("marbleSpeed")] [SerializeField] private float marbleAccel; // Creates an editable variable for marble speed on Unity
	public LayerMask groundLayers; // Make objects be considered ground
	public SphereCollider col; // Creates a sphere shaped collider that acts as a trigger for objects when touched
	private Rigidbody body; // Creates the Rigidbody(physics) for the marble

	[FormerlySerializedAs("maxSpeed")] public float maxAccel;
	public Text winText1; // Setting the winning text
	public Text winText2;
	
	// For initializing things
	void Start() {
		body = GetComponent<Rigidbody>();
		col = GetComponent<SphereCollider>();

		winText1.text = "";
		winText2.text = "";
	}
	// Like Update(), this is called once per frame, except all physics-based things should go here
	void FixedUpdate() {
//		// These record input from the horizontal and vertical axis
//		float xSpeed = Input.GetAxis("Horizontal2"); 
//		float ySpeed = Input.GetAxis("Vertical2");
//
//		// 0 For y slot because in 3D, y isn't up and down, it's height, so we need z to be ySpeed
//		// * marbleAccel to create momentum
//		// Time.deltaTime will counter FPS affecting the ball speed
//		body.AddTorque (new Vector3(xSpeed, 0, ySpeed) * marbleAccel * Time.deltaTime); 
//		// If the ball is on the ground and if spacebar is pressed, jump
//		if (IsGrounded() && Input.GetKeyDown(KeyCode.RightShift)) {
//			body.AddForce (Vector3.up * 7, ForceMode.Impulse); // Impulse adds the jump force once, not continuously
//		}

		// If the ball is on the ground and if spacebar is pressed, jump
		if (IsGrounded())
		{
			// These record input from the horizontal and vertical axis
			var xSpeed = Input.GetAxis("Horizontal2");
			var ySpeed = Input.GetAxis("Vertical2");

			// 0 For y slot because in 3D, y isn't up and down, it's height, so we need z to be ySpeed
			// * marbleAccel to create momentum
			// Time.deltaTime will counter FPS affecting the ball speed
			// body.AddTorque (new Vector3(xSpeed, 0, ySpeed) * marbleAccel * Time.deltaTime);

			// Create a Vector3 variable, and assign X and Z to feature our horizontal and vertical float variables above
			var movement = new Vector3(-ySpeed, 0.0f, xSpeed);

			// Add a physical force to our Player rigidbody using our 'movement' Vector3 above, 
			// multiplying it by 'speed' - our public player speed that appears in the inspector
			if(body.velocity.magnitude < maxAccel)
				body.AddForce(movement * marbleAccel);

			if (Input.GetKeyDown(KeyCode.RightShift))
				body.AddForce(Vector3.up * 7, ForceMode.Impulse); // Impulse adds the jump force once, not continuously
		}
	}

	// Creates a capsule inside the marble that acts as a trigger for the marble when it touches the ground
	// col.bounds.center = start of capsule
	// new Vector3(col.bounds.center.x & z = end of capsule
	// col.bounds.min.y = minimum boundary on the y axis/bottom of the marble
	// col.radius * .9f = radius of the capsule, 90% of our marble so we can't jump off walls
	private bool IsGrounded() {
		return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, 
			col.bounds.min.y, col.bounds.center.z), col.radius * .9f, groundLayers);
	}

	// This method is for collecting collectables
	void OnTriggerEnter(Collider col) {
		if (col.gameObject.CompareTag("Collectible")) {
			col.gameObject.SetActive(false);
		}
		
		if (col.name == "Finish Trigger")
		{
			winText1.text = "You Win!";
			winText2.text = "You Win!";
		}
	}
}
