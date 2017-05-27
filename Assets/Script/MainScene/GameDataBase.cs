using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataBase : MonoBehaviour {

public ItemDataBase itemDatabase;
public EffectDataBase effectDatabase;
public PlayerDataBase playerDatabase;
public EnemyDataBase enemyDatabase;
public SkillDataBase skillDatabase;
public int score = 0;

	public static GameDataBase Instance{
		get; private set;
	}
	void Start () {
		effectDatabase.SetInitialize();
		itemDatabase.SetInitialize(effectDatabase);
		enemyDatabase.SetInitialize(itemDatabase);
		playerDatabase.SetInitialize();
		skillDatabase.SetInitialize();

		if (Instance != null) {
			Destroy(gameObject);
			return;
		}
		Instance = this;
		score += 30;
		Debug.Log(score);
		
		DontDestroyOnLoad(gameObject);
	}

	public void SetDataBase () {
		effectDatabase.SetInitialize();
		itemDatabase.SetInitialize(effectDatabase);
		enemyDatabase.SetInitialize(itemDatabase);
		playerDatabase.SetInitialize();
		skillDatabase.SetInitialize();
	}

	public void getSkillData(Skill skill){
		skillDatabase.GetSkill(skill);
	}

	public void Save(){

	}
	
}
