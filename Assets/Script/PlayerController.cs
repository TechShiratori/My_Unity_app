using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float speed = 4f;
	public float jumpPower = 700;
	public LayerMask groundLayer;
	public GameObject mainCamera;
	public GameObject bullet;
	private Renderer renderer;

	private Rigidbody2D rigidbody2D;
	private Animator anim;
	private bool isGrounded;

	private float direction = 1;

	void Start () {
		anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		renderer = GetComponent<Renderer>();
	}

	void Update ()
	{
		//接地判定
		isGrounded = Physics2D.Linecast (
			transform.position + transform.up * 1,
			transform.position - transform.up * 0.05f,
			groundLayer);

		//ジャンプ中or落下中の判定
		float velY = rigidbody2D.velocity.y;
		bool isJumping = velY > 0.1f ? true:false;
		bool isFalling = velY < -0.1f ? true:false;
		anim.SetBool("isJumping",isJumping);
		anim.SetBool("isFalling",isFalling);

		//移動判定
		float x = Input.GetAxisRaw ("Horizontal");
		if (x != 0) {
			direction = x;
			toRun (x);
		}else {
			rigidbody2D.velocity = new Vector2 (0, rigidbody2D.velocity.y);
			anim.SetBool ("Run", false);
		}

		//スペースキーを押した時:ジャンプ
		if (Input.GetKeyDown ("space")) {
			toJump ();
		}
			
		//Xキーを押した時:ショット
		if (Input.GetKeyDown ("x")){
			toShot (direction);
		}
			
	}

	void toRun(float x){
		rigidbody2D.velocity = new Vector2 (x * speed, rigidbody2D.velocity.y);
		Vector2 temp = transform.localScale;
		temp.x = x;
		transform.localScale = temp;

		anim.SetBool("Run",true);

		Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
		Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		Vector2 pos = transform.position;
		pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
		transform.position = pos;
	}

	void toJump(){
		if (isGrounded) {
			anim.SetTrigger("Jump");
			isGrounded = false;
			rigidbody2D.AddForce (Vector2.up * jumpPower);
		}
	}


	void toShot(float x){
		anim.SetTrigger("Shot");
		Instantiate(bullet, transform.position + new Vector3(x,1.2f,0f), transform.rotation);
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		//Enemyとぶつかった時にコルーチンを実行
		if (col.gameObject.tag == "Enemy") {
			StartCoroutine ("Damage");
		}
	}

	IEnumerator Damage ()
	{
		//レイヤーをPlayerDamageに変更
		gameObject.layer = LayerMask.NameToLayer("PlayerDamage");
		//while文を10回ループ
		int count = 10;
		while (count > 0){
			//透明にする
			renderer.material.color = new Color (1,1,1,0);
			//0.05秒待つ
			yield return new WaitForSeconds(0.05f);
			//元に戻す
			renderer.material.color = new Color (1,1,1,1);
			//0.05秒待つ
			yield return new WaitForSeconds(0.05f);
			count--;
		}
		//レイヤーをPlayerに戻す
		gameObject.layer = LayerMask.NameToLayer("Player");
	}
}
