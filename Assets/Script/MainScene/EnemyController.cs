using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    Rigidbody2D m_rigidbody2D;
    private ActSceneContoller m_actSceneController;
    private GameDataBase m_gameDataBase;
    [SerializeField] private EnemyEffectController m_enemyEffectController;
    //private Enemy m_enemy;

    void Start()
    {
        /* 
        m_gameDataBase = GameObject.Find("GameDataBase").transform.GetComponent<GameDataBase>();
        var m_gameScene = GameObject.Find("ActScene");
        var test = m_gameScene.transform.FindChild("GameDataBase");
        Debug.Log(m_gameScene);
        */
    }

    public void SetEnemys(GameDataBase gameDataBase,ActSceneContoller actSceneController){
        m_gameDataBase = gameDataBase;
        m_actSceneController = actSceneController;
    }

    public void DeadEffect(GameObject enemyObj)
    {
        var explosion = (GameObject)Resources.Load("Effect/Explosion");
		Instantiate (explosion, enemyObj.transform.position, enemyObj.transform.rotation);
    }
    public void AttackPlayer(int enemyPower)
    {
        m_actSceneController.DamageEffect(enemyPower);
    }

    public int CalculateDamage(int enemyHp){
        int playerATK = m_actSceneController.player.playerPower;
        enemyHp -= playerATK;
        return enemyHp;
    }
}