using UnityEngine;
using System.Collections;

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
		if (Input.GetButtonDown("Jump") && playerDI.isAlive())
        {
			playerMI.Jump();
        }
    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        //player.SetAnimatorParameters();
		if(playerDI.isAlive()){
			playerMI.Move(moveHorizontal); 
		}

		if (Input.GetKeyDown (KeyCode.F)) {
			playerDI.getHit();
		}
    }
}
