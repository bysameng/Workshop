using UnityEngine;
using System.Collections;

public class HoopController : MonoBehaviour {

	public GameObject[] hoopParts;
	public Vector3[] positions;
	public Quaternion[] rotations;

	// Use this for initialization
	void Start () {
		//let's store all of our rotations and positions we'll reset to
		positions = new Vector3[hoopParts.Length];
		rotations = new Quaternion[hoopParts.Length];
		for(int i = 0; i < hoopParts.Length; i++){
			positions[i] = hoopParts[i].transform.position;
			rotations[i] = hoopParts[i].transform.rotation;
		}
	
	
	}

	//this is called when a trigger collider has a rigidbody enter it
	void OnTriggerEnter(Collider other){
		//let's check if we have it tagged as a player
		if (other.gameObject.tag == "Player"){
			//let's make sure it's falling
			if (other.gameObject.rigidbody.velocity.y < 0){
				//whee!
				Debug.Log("SCORE!");
				//now let's make each thing explode by disabling kinematic and adding force
				foreach(GameObject g in hoopParts){
					g.rigidbody.isKinematic = false;
					g.rigidbody.AddExplosionForce(100f, other.transform.position, 4f);
				}
				//start our coroutine to put our hoop back together
				StartCoroutine(Rearrange());
			}
		}
	}


	//this rearranges the hoop back to its starting position
	IEnumerator Rearrange(){
		//this line only works inside of a coroutine! wait for a couple of seconds.
		yield return new WaitForSeconds(2f);
		//for each hoop part, let's put it back to the saved positions/rotations
		for (int i = 0; i < hoopParts.Length; i++){
			hoopParts[i].transform.position = positions[i];
			hoopParts[i].transform.rotation = rotations[i];
			hoopParts[i].rigidbody.isKinematic = true;
		}


	}
}
