using UnityEngine;
using System.Collections;

public class spikes : MonoBehaviour {
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col){
		IDamageable damageableObject = col.gameObject.GetComponent<IDamageable>();
		if((damageableObject) != null){
			damageableObject.getHit();
		}
	}
}
