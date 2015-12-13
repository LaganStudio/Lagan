public class Patrol : IState
{
	private float direction = 0.5f;
	public void Action(AIController ai, IMovable dummy){
		if (ai.CheckPlatform()) {
			dummy.Move (direction);
		} else {
			direction *= -1;
			dummy.Move (direction);
		}
		if (ai.Enemy == null) {
			ai.CheckEnemy ();
		} else {
			ai.SetState(new Follow());
		}
	}
}
