using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyEffectController : MonoBehaviour {
private EnemyController m_enemyController;

    void Start()
    {
        m_enemyController = transform.parent.gameObject.GetComponent<EnemyController>();
        //m_enemyController.SetEnemy(this.gameObject);
    }

	public void ToExplode(){
		var explosion = (GameObject)Resources.Load("Effect/Explosion");
		Instantiate (explosion, transform.position, transform.rotation);
	}
}
