using UnityEngine;

public class Follow : IState {
	public void Action(AIController ai, IMovable dummy){
		Vector2 enemyPosition = new Vector2(ai.Enemy.transform.position.x, ai.Enemy.transform.position.y);
		Vector2 diff = enemyPosition - new Vector2(ai.transform.position.x, ai.transform.position.y);
	 	if (diff.y > 3.0f) {
			dummy.Jump();
		}
		dummy.Move (diff.normalized.x);
	}
}
