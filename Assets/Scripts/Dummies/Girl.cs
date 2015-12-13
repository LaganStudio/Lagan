using UnityEngine;
using System.Collections;

public class Girl : Humanoid, IDamageable{
	public int maxHP;
	private int currentHP;
	private bool _isAlive = true;
	void Start(){
		base.Start();
		currentHP = maxHP;
	}
    public void FixedUpdate()
    {
        CheckGround();
        SetAnimatorParameters();
		AnimatorDeathCheck();
        FacingHandler();
    }
	public bool isAlive()
	{
		return _isAlive;
	}
	public void getHit()
	{
		if (isAlive ()) {
			print("Получил удар");
			currentHP -= 10;
			print("Осталось " + currentHP + "HP");
			if(currentHP<=0){
				print("Персонаж умер");
				_isAlive = false;
			}
		}
	}
	private void AnimatorDeathCheck()
	{
		anim.SetBool ("isAlive", _isAlive);
	}
}