using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataBase : MonoBehaviour {

public ItemDataBase itemDatabase;
public EffectDataBase effectDatabase;
public PlayerDataBase playerDatabase;
public EnemyDataBase enemyDatabase;
public SkillDataBase skillDatabase;

	void Start () {
		effectDatabase.SetInitialize();
		itemDatabase.SetInitialize(effectDatabase);
		enemyDatabase.SetInitialize(itemDatabase);
		playerDatabase.SetInitialize();
		skillDatabase.SetInitialize();
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
	
}
