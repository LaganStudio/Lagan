using UnityEngine;
using System.Collections;

public class AIController : MonoBehaviour {
	public Transform checker;
	public LayerMask whatIsPlatform, whatIsPlayer;

	private Transform enemy;
	private IState state;
	private IMovable dummy;
	private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () 
	{	
		dummy = GetComponent<IMovable>();
		rb2d = GetComponent<Rigidbody2D> ();
		state = new Patrol ();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	public bool CheckPlatform(){
		RaycastHit2D hit = Physics2D.Raycast(checker.position,rb2d.velocity.normalized,0.3f,whatIsPlatform);
		//Debug.Log (hit.collider);
		if (hit.collider != null) {
			return false;
		} 
		hit = Physics2D.Raycast(checker.position,Vector2.down,1.2f,whatIsPlatform);
		if (hit.collider != null) {
			return true;
		} 
		return false;
	}

	public void SetState(IState state){
		this.state = state;
	}
	public Transform Enemy{
		get { return enemy; }
		set { enemy = value; }
	}
	public void CheckEnemy(){
		RaycastHit2D hit = Physics2D.Raycast(checker.position,rb2d.velocity.normalized,100f,whatIsPlayer);
		if (hit.collider != null) {
			Enemy = hit.transform;
			Debug.Log("НАШЕЛ ИГРОКА");
		} 
	}

	void FixedUpdate()
	{
		state.Action (this, dummy);
	}
}
