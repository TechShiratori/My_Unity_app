using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SearchScript : MonoBehaviour {

	void OnTriggerStay2D(Collider2D col){
		if (col.gameObject.tag == "UnityChan")
        {
			var actionEnemy = transform.parent.GetComponent<EnemyScript>();
			Debug.Log("索敵範囲");
			//actionEnemy.ToTrace();
        }
	}
}
