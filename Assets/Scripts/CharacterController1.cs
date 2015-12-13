using UnityEngine;

public class CharacterController1 : MonoBehaviour {
    public GameObject playerGO;

	protected IDamageable playerDI;
	protected IMovable playerMI;
	// Use this for initialization
	void Start () {
		playerMI = playerGO.GetComponent<IMovable> ();
		playerDI = playerGO.GetComponent<IDamageable> ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Jump") && playerDI.IsAlive())
        {
			playerMI.Jump();
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //player.SetAnimatorParameters();
		if(playerDI.IsAlive()){
			playerMI.Move(moveHorizontal);
		} else {
            playerMI.Move(0.0f);
        }
    }
}
