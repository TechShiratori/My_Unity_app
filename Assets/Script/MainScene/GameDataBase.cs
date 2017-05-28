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
		/* 
		List<string> strs = new List<string>();
		List<int> itemListID = new List<int>();
		strs.Add("abc");
		strs.Add("def");
		itemListID.Add(1);
		itemListID.Add(112);
		ES2.Save(strs, "stringList");
		ES2.Save(itemListID,"saveList");
		
		Test aaa = new Test("aad",3,"bbw",3.0f,5);
		ES2.Save(aaa,"SaveList3");
		*/
		Test test = new Test("かかかかk");
		test.Hp = 130;
		Skill testSkill = new Skill("aaa");
		testSkill.needExp = 100;
		string saveJson = LitJson.JsonMapper.ToJson(test);
		string saveJson2 = LitJson.JsonMapper.ToJson(testSkill);
		string saveJson3 = LitJson.JsonMapper.ToJson(skillDatabase.mySkills);
		saveJson3 = System.Text.RegularExpressions.Regex.Unescape(saveJson3);
		Debug.Log(saveJson3);
		ES2.Save(saveJson3, "player?tag=json");

		/* 
		foreach(var mySkill in skillDatabase.mySkills){
			//ES2.Save(aaa,"SaveList3");
		}
		*/

		
	}
	
}
