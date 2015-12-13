using UnityEngine;
using System.Collections;

public class Follow : IState {
	void Start () {
	
	}
	public void Action(AIController ai, IMovable dummy){
		//Debug.Log ("Перешел в это гавно");
		Vector2 enemyPosition = new Vector2(ai.Enemy.transform.position.x, ai.Enemy.transform.position.y);
		Vector2 diff = enemyPosition - new Vector2(ai.transform.position.x, ai.transform.position.y);
		//Debug.Log (diff);
	 	if (diff.y > 3.0f) { 
			dummy.Jump();
		}
		dummy.Move (diff.normalized.x);
	}
}
