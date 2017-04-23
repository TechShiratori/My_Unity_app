using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

	public GameObject enemyPrefab;

	public float timeCount = 0;
	public int enemyCount = 0;

	private float sponeArea;
	private GameObject[] enemy;

	// 敵の生成位置：X座標
	private float genPosX = 25;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		enemy = GameObject.FindGameObjectsWithTag("Enemy");
		timeCount += Time.deltaTime;
		int rand = Random.Range (-50, 50);


		if (timeCount > 5 && enemy.Length < 10) {
			//Debug.Log(enemy.Length);
			float test = (float)(rand * 0.1);
			GameObject sponeEnemy = Instantiate (enemyPrefab) as GameObject;
			sponeEnemy.transform.position = new Vector2 (this.genPosX + test, 1);
			timeCount = 0;
		}

	}
}
