using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataBase : MonoBehaviour {

public ItemDataBase itemDatabase;
public EffectDataBase effectDatabase;
public PlayerDataBase playerDatabase;
public EnemyDataBase enemyDatabase;

	void Start () {
		//playerDatabase.SetInitialize();
		effectDatabase.SetDataBase();
		itemDatabase.SetDataBase(effectDatabase);
		enemyDatabase.SetInitialize(itemDatabase);
		playerDatabase.SetInitialize();
	}

	public void SetDataBase () {
		//playerDatabase.SetInitialize();
		effectDatabase.SetDataBase();
		itemDatabase.SetDataBase(effectDatabase);
		enemyDatabase.SetInitialize(itemDatabase);
		Debug.Log(enemyDatabase.enemy.Count);
		playerDatabase.SetInitialize();
	}
}
