using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

	public int healPoint = 20;
	private LifeController lifeScript;
	void Start ()
	{
		//HPタグの付いているオブジェクトのLifeScriptを取得
		lifeScript = GameObject.FindGameObjectWithTag("HP").GetComponent<LifeController>();
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		//ユニティちゃんと衝突した時
		if (col.gameObject.tag == "UnityChan") {
			//LifeUpメソッドを呼び出す　引数はhealPoint
			lifeScript.LifeUp(healPoint);
			//アイテムを削除する
			Destroy(gameObject);
		}
	}
}
