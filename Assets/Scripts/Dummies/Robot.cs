using UnityEngine;
using System.Collections;

public class Robot : Humanoid, IDamageable {
    public void FixedUpdate()
    {
        CheckGround();
        SetAnimatorParameters();
        FacingHandler();
    }
	public bool IsAlive()
	{
		return true;
	}
	public void Kill()
	{
		if (IsAlive()) {
			Debug.Log ("Получил удар");
		}
    }
    public void GetHit(int damage){
        print("Get " + damage + " damage");
    }
}
