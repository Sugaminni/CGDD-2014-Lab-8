// A Simple Movement Script
// Author: Jeff Chastine
using UnityEngine;
using System.Collections;


public class MovementScript : MonoBehaviour {

	public float runSpeed = 3.0f;
	public bool isActive = true;
	private float h = 0.0f; // Horizontal input (A, D)
	private float dfs = 0.0f; // The direction the character is facing
	private bool isColliding;
	private Vector3 resetPosition;
	private int score = 0;

	// Use this for initialization
	void Start () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.tag == "Gem") {
			score++;
			Debug.Log("Score: "+score);
			Destroy(other.gameObject);
		}
	}

	// Fixed Update is called once per frame
	void FixedUpdate () {
		bool toTheLeft = (transform.position.x < -4.0f);
		bool toTheRight = (transform.position.x > 4.0f);
		if (toTheLeft||toTheRight) {
			h = 0;
			resetPosition = transform.position;
			if (toTheLeft) {
				resetPosition.x = -4;
			}
			else {
				resetPosition.x = 4;
			}
			transform.position = resetPosition;
		}
		if (((transform.position.x==-4)&&(h < -0.1f)) || ((transform.position.x==4)&&(h > 0.1f))){
			h = 0.0f;
		}
		else {
			h = Input.GetAxis("Horizontal");

		}

		if (h >0.1f) {
			dfs = 45.0f;
		}
		else if (h < -0.1f) {
			dfs = -45.0f;
		}
		else {
			dfs = 0.0f;
		}

		Vector3 lookAtTarget = Quaternion.AngleAxis(dfs, Vector3.up)*Vector3.forward + transform.position;
		transform.LookAt(lookAtTarget);
		transform.Translate(Vector3.forward*Time.deltaTime*runSpeed);
	}// Fixed Update
}
