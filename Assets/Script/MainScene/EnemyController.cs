using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour
{

    Rigidbody2D m_rigidbody2D;
    [SerializeField] private ActSceneContoller m_actSceneController;
    [SerializeField] private GameDataBase m_gameDataBase;
    [SerializeField] private EnemyEffectController m_enemyEffectController;
    private Enemy m_enemy;

    void Start()
    {
    }

    public void DeadEffect(GameObject enemyObj)
    {
        var explosion = (GameObject)Resources.Load("Effect/Explosion");
		Instantiate (explosion, enemyObj.transform.position, enemyObj.transform.rotation);
    }


    public void DamageEffect(int enemyPower)
    {
        m_actSceneController.DamageEffect(enemyPower);
    }
}