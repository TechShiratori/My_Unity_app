using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    private EnemyController m_enemyController;
    private GameDataBase m_gameDataBase;
    private ActSceneContoller m_actSceneController;
    private Enemy m_enemy;
    private int m_hp; //敵各個体のHP
    private int m_exp; //敵各個体の経験値
    private Enemy.EnemyStatus m_status;
    private GameObject m_dropItemObj;
    private GameObject m_dropExpObj;
	private GameObject m_player;
	private Rigidbody2D m_rigidbody2D;
	
	//メインカメラのタグ名　constは定数(絶対に変わらない値)
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    //カメラに映っているかの判定
    private bool _isRendered = false;


    void Start()
    {
		m_player = GameObject.FindWithTag("UnityChan");
		m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_enemyController = GameObject.Find("EnemyController").transform.GetComponent<EnemyController>();
        m_gameDataBase = m_enemyController.SetDataBase();
        SetEnemyStatus(gameObject);
        m_hp = m_enemy.enemyLife;
        m_exp = m_enemy.enemyEXP;
    }

    private void ToTrace(){
        if (m_player.transform.position.x < this.transform.position.x)
            {
                toMove(-1);
            }
        else if (m_player.transform.position.x > this.transform.position.x)
            {
                toMove(1);
            }
    }

	void FixedUpdate()
    {
        if (_isRendered){
            ToTrace();
        }
    }

    private void EnemyState(){
        
    }

	private void toMove(float x)
    {
        
        m_rigidbody2D.velocity = new Vector2(m_enemy.enemySpeed * 0.1f * x, m_rigidbody2D.velocity.y);

        Vector2 temp = transform.localScale;
        temp.x = -x;
        this.transform.localScale = temp;
    }

    public void SetEnemyStatus(GameObject enemyObj)
    {
        var i = 0;
        foreach (var enemyData in m_gameDataBase.enemyDatabase.enemys)
        {
            var selectEnemyName = gameObject.name.Replace("(Clone)","");
            if (enemyData.enemyName == selectEnemyName)
            {
                m_enemy = m_gameDataBase.enemyDatabase.enemys[i];
                var itemName = "Prefab/" + m_enemy.enemyItem.itemName.ToString();
                var expName = "Prefab/ExpPoint";
                m_dropItemObj = (GameObject)Resources.Load(itemName);
                m_dropExpObj = (GameObject)Resources.Load(expName);
                //m_dropExpObj.name = m_enemy.enemyEXP.ToString();
                return;
            }
            i++;
        }
    }

	void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "UnityChan")
        {
            m_enemyController.AttackPlayer(m_enemy.enemyPower);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (_isRendered && col.tag == "Bullet")
        {
            m_hp = m_enemyController.CalculateDamage(m_hp);
            Debug.Log("残りHP ： " + m_hp);
            if (m_hp <= 0)
            {
                m_status = Enemy.EnemyStatus.Dead;
                m_enemyController.DeadEffect(gameObject);
				int randomValue = Random.Range(0, 100);
				if (randomValue <= m_enemy.itemDropProbability)
				{
					Instantiate(m_dropItemObj, transform.position, transform.rotation);
				}
				var expObj = Instantiate(m_dropExpObj, transform.position, transform.rotation);
                expObj.name =m_exp.ToString();
                Destroy(gameObject);
            }
        }


    }

    public void DropItem()
    {
        int randomValue = Random.Range(0, 100);
        if (randomValue <= m_enemy.itemDropProbability)
        {
            Instantiate(m_dropItemObj, transform.position, transform.rotation);
        }
		Instantiate(m_dropExpObj, transform.position, transform.rotation);
    }

	void OnWillRenderObject()
    {
        //メインカメラに映った時だけ_isRenderedをtrue
        if (Camera.current.tag == MAIN_CAMERA_TAG_NAME)
        {
            _isRendered = true;
        }
    }
}

