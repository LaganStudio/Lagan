using UnityEngine;

public class BulletController : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D col){
		IDamageable damageableObject = col.gameObject.GetComponent<IDamageable>();
		if((damageableObject) != null){
			damageableObject.Kill();
			Destroy(gameObject);
		}
	}
}
