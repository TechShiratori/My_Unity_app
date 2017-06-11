using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour {

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "UnityChan")
        {
			var actionEnemy = transform.parent.GetComponent<EnemyScript>();
			Debug.Log("攻撃範囲");
        }
	}
}
