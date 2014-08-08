using UnityEngine;
using System.Collections;

public class PlaneTilter : MonoBehaviour {

	private bool rotationDirection; // if true, rotate counterclockwise

	
	// Update is called once per frame
	void Update () {
		Quaternion delta;

		if (rotationDirection){
			//rotate counterclockwise
			delta = Quaternion.Euler(new Vector3(0, 0, 10f) * Time.deltaTime);
		}
		
		else {
			//rotate clockwise
			delta = Quaternion.Euler(new Vector3(0, 0, -10f) * Time.deltaTime);
		}

		//apply the rotation with our rigidbody
		rigidbody.MoveRotation(rigidbody.rotation * delta);

		//so here's where we need more logic
		//since the rotations wrap around to 360, we need some maths!
		if (rigidbody.rotation.eulerAngles.z < 350 && rigidbody.rotation.eulerAngles.z > 10){
			//switch our rotation direction
			rotationDirection = true;
		}
		if (rigidbody.rotation.eulerAngles.z > 10 && rigidbody.rotation.eulerAngles.z < 340){
			rotationDirection = false;
		}
	}


}
