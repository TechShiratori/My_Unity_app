using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private float m_searchArea = 10;
    [SerializeField] private float m_attackArea = 2;
    [SerializeField] private float m_attackCoolTime = 2;

    private EnemyController m_enemyController;
    private GameDataBase m_gameDataBase;
    private ActSceneContoller m_actSceneController;
    private Enemy m_enemy;
    private int m_hp; //敵各個体のHP
    private int m_exp; //敵各個体の経験値
    private Enemy.EnemyStatus m_status;
    private GameObject m_dropItemObj;
    private GameObject m_dropExpObj;
	private GameObject m_target;
	private Rigidbody2D m_rigidbody2D;
    private float m_direction = 1;
    private float m_targetDirection = 1;
	
	//メインカメラのタグ名　constは定数(絶対に変わらない値)
    private const string MAIN_CAMERA_TAG_NAME = "MainCamera";
    //カメラに映っているかの判定
    private bool _isRendered = false;
    private float distanceX;
    private float distanceY;
    public void InitializeEnemy(){
        m_target = GameObject.FindWithTag("UnityChan");
		m_rigidbody2D = GetComponent<Rigidbody2D>();
        m_enemyController = transform.parent.GetComponent<EnemyController>();
        m_enemy = m_enemyController.SetEnemyStatus(gameObject);
        m_hp = m_enemy.enemyLife;
        m_exp = m_enemy.enemyEXP;   
    }

    public void ToAction(){
        distanceX = m_target.transform.position.x - gameObject.transform.position.x;
        distanceY = m_target.transform.position.x - gameObject.transform.position.y;
        m_direction = (distanceX) / Mathf.Abs(distanceX);

        if(Mathf.Abs(distanceX) > m_attackArea && Mathf.Abs(distanceX) < m_searchArea && (m_status == Enemy.EnemyStatus.Wait || m_status == Enemy.EnemyStatus.Trace)){
            m_status = Enemy.EnemyStatus.Trace;
            ToMove(m_direction);
        }else if(Mathf.Abs(distanceX) > m_attackArea && Mathf.Abs(distanceX) < m_searchArea && (m_status == Enemy.EnemyStatus.Wait || m_status == Enemy.EnemyStatus.Trace)){
            m_status = Enemy.EnemyStatus.Trace;
            ToMove(m_direction);
        }else if(Mathf.Abs(distanceX) < m_attackArea && (m_status == Enemy.EnemyStatus.Wait || m_status == Enemy.EnemyStatus.Trace)){
            m_status = Enemy.EnemyStatus.Attack;
            Debug.Log("攻撃");
            ToAttack();
        }else if (m_status == Enemy.EnemyStatus.Charge){
            ToCharge();
        }else if (m_status != Enemy.EnemyStatus.Charge && m_status != Enemy.EnemyStatus.Attack){
            m_status = Enemy.EnemyStatus.Wait;
            ToTraceWait();
        }
        Debug.Log(m_status);
    }

    private void ToAttack(){
        m_status = Enemy.EnemyStatus.Attack;
        StartCoroutine("Attack",m_direction);
    }
    
    private void ToTraceWait(){
        m_rigidbody2D.velocity = new Vector2(0,m_rigidbody2D.velocity.y);
    }

	private void ToMove(float x)
    {
        m_rigidbody2D.velocity = new Vector2(m_enemy.enemySpeed * 0.1f * x, m_rigidbody2D.velocity.y);

        Vector2 temp = transform.localScale;
        temp.x = -x;
        this.transform.localScale = temp;
    }

    private void ToCharge(){
        m_rigidbody2D.velocity = new Vector2(0,m_rigidbody2D.velocity.y);
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

    private IEnumerator Attack(float x){
        int dashPower = 600;
        m_status = Enemy.EnemyStatus.Attack;
		for(int i = 0; i < 5 ; i++){
			m_rigidbody2D.AddForce(Vector2.right * dashPower * x);
			yield return null;
		}
        m_status = Enemy.EnemyStatus.Charge;
        yield return new WaitForSeconds(m_attackCoolTime);
        m_status = Enemy.EnemyStatus.Wait;
    }
}

