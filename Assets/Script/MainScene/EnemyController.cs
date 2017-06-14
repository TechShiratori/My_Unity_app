using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    Rigidbody2D m_rigidbody2D;
    private ActSceneContoller m_actSceneController;
    private GameDataBase m_gameDataBase;
    [SerializeField] private EnemyEffectController m_enemyEffectController;



    public void SetEnemys(GameDataBase gameDataBase,ActSceneContoller actSceneController){
        m_gameDataBase = gameDataBase;
        m_actSceneController = actSceneController;

        //EnemyController下の子のエネミーたちをセット（最初の一回だけだからジェネレーターは随時せっと）
        foreach(Transform child in transform){
            if(child.gameObject.tag == "Enemy"){
                child.GetComponentInChildren<EnemyScript>().InitializeEnemy();
            }
        }
    }
    public void EnemyAction(){
        if (null != this)
        {
            foreach (Transform child in transform)
            {
                if (child.gameObject.tag == "Enemy")
                {
                    child.GetComponentInChildren<EnemyScript>().ToAction();
                }
            }
        }
    }

    public Enemy SetEnemyStatus(GameObject enemyObj){
       foreach (var enemyData in m_gameDataBase.enemyDatabase.enemys)
        {
            var i = 0;
            var selectEnemyName = enemyObj.name.Replace("(Clone)","");
            if (enemyData.enemyName == selectEnemyName)
            {
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