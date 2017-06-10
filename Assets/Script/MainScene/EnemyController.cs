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
        
        m_gameDataBase = GameObject.Find("GameDataBase").transform.GetComponent<GameDataBase>();
        
    }

    public void SetEnemys(GameDataBase gameDataBase,ActSceneContoller actSceneController){
        m_gameDataBase = gameDataBase;
        m_actSceneController = actSceneController;
    }

    public GameDataBase SetDataBase(){
        return m_gameDataBase;
    }

    public Enemy SetEnemyStatus(GameObject enemyObj){
       foreach (var enemyData in m_gameDataBase.enemyDatabase.enemys)
        {
            var i = 0;
            var selectEnemyName = enemyObj.name.Replace("(Clone)","");
            Debug.Log(selectEnemyName);
            if (enemyData.enemyName == selectEnemyName)
            {
                Debug.Log(enemyData.enemyLife);
                return m_gameDataBase.enemyDatabase.enemys[i];
            }
            i++;
        }
        return null;
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
        int playerATK = m_actSceneController.player.playerPower + m_actSceneController.player.equipWeapon.weaponPower;
        Debug.Log("与えたダメージ : " + playerATK);
        enemyHp -= playerATK;
        return enemyHp;
    }
}