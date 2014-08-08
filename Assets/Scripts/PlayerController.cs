using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour { 

	// Use this for initialization
	void Start () {
		//notice now this only runs once when we start the game or create a player
		Debug.Log("HELLO I EXIST NOTICE ME");
	}
	
	// Update is called once per frame
	void Update () {
		//declare force
		Vector3 force;
		//instantiate force to a new instance of Vector3
		force = new Vector3(0, 0, 0);


		//new! if this key is pressed let's restart the scene
		if (Input.GetKeyDown(KeyCode.R)){
			Application.LoadLevel(Application.loadedLevel);
		}

		if (Input.GetKey(KeyCode.RightArrow)){
			//this will only run if RIGHTARROW IS PRESSED
			force.x += 1000f;
		}
		
		if (Input.GetKey(KeyCode.LeftArrow)){
			//this will only run if LEFTARROW IS PRESSED
			force.x -= 1000f;
		}

		if (Input.GetKey(KeyCode.UpArrow)){
			//this will only run if UPARROW IS PRESSED
			force.z += 1000f;
		}

		if (Input.GetKey(KeyCode.DownArrow)){
			//this will only run if DOWNARROW IS PRESSED
			force.z -= 1000f;
		}

		if (Input.GetKeyDown(KeyCode.Space)){
			//this will only run if SPACE IS PRESSED
			force.y += 10000f;
		}

		//now let's modulate force by the framerate so it's independent of it
		force = force * Time.deltaTime;
		//now let's apply our force!!
		rigidbody.AddForce(force);
	}
}
