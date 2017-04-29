using UnityEngine;
using System.Collections;

public class EnemyController: MonoBehaviour {

	Rigidbody2D rigidbody2D;
	public int speed = -3;
	public GameObject explosion;
	public GameObject item;

	public int attackPoint = 10;
	private LifeController lifeScript;
	//[SerializeField] private GameObject LifeControllerObject;

	private GameObject unitychan;

	//メインカメラのタグ名　constは定数(絶対に変わらない値)
	private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
	//カメラに映っているかの判定
	private bool _isRendered = false;


	void Start () {
		rigidbody2D = GetComponent<Rigidbody2D>();
		this.unitychan = GameObject.FindWithTag ("UnityChan");
	}

	void Update () {
		if (_isRendered) {
			
			if (this.unitychan.transform.position.x < this.transform.position.x) {
				toMove (1);

			} else if (this.unitychan.transform.position.x > this.transform.position.x) {
				toMove (-1);
			}
		}
	}
		
	void toMove(float x){
		rigidbody2D.velocity = new Vector2 (speed * x, rigidbody2D.velocity.y);

		Vector2 temp = transform.localScale;
		temp.x = x;
		this.transform.localScale = temp;
	}


	void OnTriggerEnter2D (Collider2D col)
	{
		if (_isRendered) {
			if (col.tag == "Bullet") {
				Destroy (gameObject);
				Instantiate (explosion, transform.position, transform.rotation);
				if (Random.Range (0, 4) == 0) {
					Instantiate (item, transform.position, transform.rotation);
				}
			}
		}
	}


	void OnCollisionEnter2D (Collision2D col)
	{
		//UnityChanとぶつかった時
		if (col.gameObject.tag == "UnityChan") {
			lifeScript = GameObject.Find("PlayerUI").GetComponent<LifeController>();
			//LifeScriptのLifeDownメソッドを実行
			lifeScript.LifeDown(attackPoint);
			lifeScript.InfectionUp(attackPoint/10);
		}
	}

	//Rendererがカメラに映ってる間に呼ばれ続ける
	void OnWillRenderObject()
	{
		//メインカメラに映った時だけ_isRenderedをtrue
		if(Camera.current.tag == MAIN_CAMERA_TAG_NAME){
			_isRendered = true;
		}
	}
}