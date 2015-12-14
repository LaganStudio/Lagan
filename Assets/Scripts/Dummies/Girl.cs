public class Girl : Humanoid, IDamageable{
	public int maxHP = 100;
	private int currentHP;
	private bool alive = true;
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
	public bool IsAlive()
	{
		return alive;
	}
	public void Kill()
	{
		if (IsAlive()) {
			print("Персонаж умер");
			alive = false;
		}
    }

	public void GetHit(int damge){
		print("Получил удар");
		currentHP -= 10;
		print("Осталось " + currentHP + "HP");
		if(currentHP<=0){
            alive = false;
        }
	}
	private void AnimatorDeathCheck()
	{
		anim.SetBool ("isAlive", alive);
	}
}
