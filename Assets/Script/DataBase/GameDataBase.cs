using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataBase : MonoBehaviour {

//今後ゲーム終了等まで使っていくプレイヤーの現在状態。（セーブロード時もこれを使う）
public Player currentPlayer;
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
		currentPlayer = currentPlayer.SetInitialize(currentPlayer);
		effectDatabase.SetInitialize();
		itemDatabase.SetInitialize(effectDatabase);
		enemyDatabase.SetInitialize(itemDatabase);
		skillDatabase.SetInitialize();
	}

	public void Initialize () {
		currentPlayer = currentPlayer.SetInitialize(currentPlayer);
		effectDatabase.SetInitialize();
		itemDatabase.SetInitialize(effectDatabase);
		enemyDatabase.SetInitialize(itemDatabase);
		//playerDatabase.SetInitialize();
		skillDatabase.SetInitialize();
	}

	public void getSkillData(Skill skill){
		skillDatabase.GetSkill(skill);
	}

	public void Save(Player player){
		string saveJson = LitJson.JsonMapper.ToJson(player);
		saveJson = System.Text.RegularExpressions.Regex.Unescape(saveJson);
		Debug.Log(saveJson);
		ES2.Save(saveJson, "player?tag=json");
	}

	public Player Load(){
		//skillDatabase.ClearMySkill();
		string loadJson = ES2.Load<string>("player?tag=json");
		Debug.Log(loadJson);
		//Skill loadskill = new Skill();
		currentPlayer = LitJson.JsonMapper.ToObject<Player>(loadJson);
		return currentPlayer;
		/* 
		foreach(var skill in skills){
			Debug.Log(skill.skillName);
			skillDatabase.GetSkill(skill);
		}
		*/
	}
	
}
