using UnityEngine;
using System.Collections;

public class EnemyController: MonoBehaviour {

	Rigidbody2D rigidbody2D;
	public int speed = -3;
	//********** 開始 **********//
	public GameObject explosion;
	//********** 終了 **********//

	//********** 開始 **********//
	public int attackPoint = 10;
	public LifeController lifeScript;
	//********** 終了 **********//

	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void Update () {
		rigidbody2D.velocity = new Vector2 (speed, rigidbody2D.velocity.y);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.tag == "Bullet") {
			Destroy (gameObject);
			Instantiate (explosion, transform.position, transform.rotation);
		}
	}
	//********** 開始 **********//
	void OnCollisionEnter2D (Collision2D col)
	{
		//UnityChanとぶつかった時
		if (col.gameObject.tag == "UnityChan") {
			//LifeScriptのLifeDownメソッドを実行
			lifeScript.LifeDown(attackPoint);
		}
	}
	//********** 終了 **********//
}