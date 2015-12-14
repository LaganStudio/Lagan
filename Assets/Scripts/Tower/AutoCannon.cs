using UnityEngine;

public class AutoCannon : MonoBehaviour {
	public GameObject bullet;
	public GameObject startEdge, endEdge;
	public GameObject trunk;
	public int force;
	public float reloadTime; //время перезарядки
	private float coolDown;



	void Start(){
		coolDown = reloadTime;
	}
	private Vector2 TrunkDirection{
		get { return new Vector2(endEdge.transform.position.x, endEdge.transform.position.y) - new Vector2(startEdge.transform.position.x, startEdge.transform.position.y);	}
	}
	void FixedUpdate(){
		//TrunkDirection = Vector2.up;
		if(coolDown == reloadTime){
			GameObject newObject = (GameObject)Instantiate(bullet, endEdge.transform.position,trunk.transform.rotation);
			Rigidbody2D newRB2D =  newObject.GetComponent<Rigidbody2D>();
			newRB2D.AddForce(TrunkDirection*force);
			Destroy(newObject, 10);
			coolDown -= Time.fixedDeltaTime;
		} else {
			if(coolDown < 0){
				coolDown = reloadTime;
			} else {
				coolDown -= Time.fixedDeltaTime;
			}
		}

	}
}
