using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]//この属性を使ってインスペクター上で表示
public class Player{
	public string playerName;
	public int playerID;
	public string playerDesc; //プレイヤーの状態や現在地を文章で用意しておく。いらないかも
	public int playerLife; //プレイヤーのHP
	public int playerMaxLife; //プレイヤーのHP
	public int playerInfection; //プレイヤーの感染率
	public int playerErosion; //プレイヤーの侵食率
	public int playerPower; //プレイヤーの基礎攻撃力
	public int playerSpeed; //プレイヤーの移動速度
	public string playerSave; //プレイヤーが直前にセーブした場所
	public PlayerHealth playerHealth;
	public PlayerStatus playerStatus;
	public enum PlayerHealth	//プレイヤーの現在ステータス(HP関連) いらないかも
	{
		Fine,
		Caution,
		Danger,
		Dead
	}
	public enum PlayerStatus	//プレイヤーの現在ステータス(状態異常関連)
	{
		None,
		Poison,
		Bind,
		PowerUP,
		SpeedUP,
		DefenceUP,
		Other
	}
	public List<Item> playerItems;
	public List<Skill> playerSkill;
	public int playerExp;

	public Player(string name, int id, string desc, int life, int maxlife, int infection, int erosion ,int power, int speed, PlayerHealth health, PlayerStatus status,string save, List<Item> items, List<Skill> skills, int exp)
    {
        playerName = name;
        playerID = id;
        playerDesc = desc;
        playerLife = life;
		playerMaxLife = maxlife;
		playerInfection = infection;
		playerErosion = erosion;
        playerPower = power;
        playerSpeed = speed;
        playerHealth = health;
		playerStatus = status;
		playerSave = save;
		playerItems = items;
		playerSkill = skills;
		playerExp = exp;
    }
	public Player(){

	}
	public Player SetInitialize(Player player)	//初期のプレイヤーデータ。最初から始めた時用
    {
		List<Item> initializeItems = new List<Item>();
		List<Skill> initializeSkill = new List<Skill>();
		player = new Player("リゼ=アルコット",0,"裏切りの科学者",100,100,0,0,10,10,Player.PlayerHealth.Fine,Player.PlayerStatus.None,"",initializeItems,initializeSkill,0);
		return player;
	}

	public Player SetCurrentPlayer(Player player)	//初期のプレイヤーデータ。最初から始めた時用
    {
		return player;
	}
}
