using UnityEngine;

public class TrunkRotation : MonoBehaviour {
	bool goingUp;
	// Use this for initialization
	void Start () {
		goingUp = true;
		transform.rotation = Quaternion.Euler(new Vector3(0,0,330));
	}

	// Update is called once per frame
	void Update () {
		//Debug.Log(transform.rotation);
		if(goingUp){
			if(transform.rotation.eulerAngles.z >= 330 || transform.rotation.eulerAngles.z < 0.5){
				transform.Rotate(new Vector3(0,0,-10*Time.deltaTime));
			} else {
				transform.rotation = Quaternion.Euler(new Vector3(0,0,330));
				goingUp = !goingUp;
			}
		} else {
			if(transform.rotation.eulerAngles.z < 0.5 || transform.rotation.eulerAngles.z >= 330){
				transform.Rotate(new Vector3(0,0,10*Time.deltaTime));
			} else {
				transform.rotation = Quaternion.Euler(new Vector3(0,0,360));
				goingUp = !goingUp;
			}
		}
	}
}
