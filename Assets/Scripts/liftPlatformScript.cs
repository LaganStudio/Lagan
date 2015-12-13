using UnityEngine;
using System.Collections;

public class liftPlatformScript : MonoBehaviour {
	private Rigidbody2D rgbd2d;
	private BoxCollider2D boxCol2d;
	public LayerMask whatIsPlayer;
	public Transform lowerPoint, higherPoint;
	public Vector2 upVel, downVel;
	// Use this for initialization
	void Start () {
		rgbd2d = GetComponent<Rigidbody2D>();
		boxCol2d = GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/*void FixedUpdate(){
		if (boxCol2d.IsTouchingLayers(whatIsPlayer)){
			if (rgbd2d.position.y<higherPoint.position.y){
				if(rgbd2d.velocity!=upVel){ rgbd2d.velocity=upVel;}
			} else {
				rgbd2d.velocity=Vector2.zero;
			}
		} else {
			if (rgbd2d.position.y>lowerPoint.position.y){
				if(rgbd2d.velocity!=downVel){rgbd2d.velocity=downVel;}
			} else {
				rgbd2d.velocity=Vector2.zero;
			}
		}
	}*/
	void FixedUpdate(){
		if (boxCol2d.IsTouchingLayers(whatIsPlayer)){
			if (rgbd2d.position.y<higherPoint.position.y){
				rgbd2d.MovePosition(Vector2.MoveTowards(rgbd2d.position, higherPoint.position, 0.07f));
			} else {
				rgbd2d.velocity=Vector2.zero;
			}
		} else {
			if (rgbd2d.position.y>lowerPoint.position.y){
				rgbd2d.MovePosition(Vector2.MoveTowards(rgbd2d.position, lowerPoint.position, 0.07f));
			} else {
				rgbd2d.velocity=Vector2.zero;
			}
		}
	}

}
