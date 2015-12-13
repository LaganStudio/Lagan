using UnityEngine;
using System.Collections;

public class movingPlatformScript : MonoBehaviour {
	private Rigidbody2D rgbd2d;
	public bool isGoingUpwards = true;
	public Transform lowerPoint, higherPoint;
	// Use this for initialization
	void Start () {
		rgbd2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate(){
		if (isGoingUpwards){
			if (rgbd2d.position.y<higherPoint.position.y){
				rgbd2d.MovePosition(Vector2.MoveTowards(rgbd2d.position, higherPoint.position, 0.07f));
			} else {
				isGoingUpwards=false;
			}
		} else {
			if (rgbd2d.position.y>lowerPoint.position.y){
				rgbd2d.MovePosition(Vector2.MoveTowards(rgbd2d.position, lowerPoint.position, 0.07f));
			} else {
				isGoingUpwards=true;
			}
		}
	}
	
}
