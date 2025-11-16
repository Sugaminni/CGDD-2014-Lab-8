using UnityEngine;
using System.Collections;

public class InitializeLevel : MonoBehaviour {


	// Use this for initialization
	void Start () {
		// Create the walls and pillars
		for (int i = 0; i < 1000; i+=10) {
			GameObject leftPillar = (GameObject)Instantiate(Resources.Load("Pillar"));
			leftPillar.transform.position = new Vector3(-5.0f, 0, i);
			GameObject rightPillar = (GameObject)Instantiate(Resources.Load("Pillar"));
			rightPillar.transform.position = new Vector3(5.0f, 0, i);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
