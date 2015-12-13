using UnityEngine;
using System.Collections;

public class Robot : Humanoid, IDamageable {
    public void FixedUpdate()
    {
        CheckGround();
        SetAnimatorParameters();
        FacingHandler();
    }
	public bool isAlive()
	{
		return true;
	}
	public void getHit()
	{
		if (isAlive ()) {
			Debug.Log ("Получил удар");
		}
	}
}
