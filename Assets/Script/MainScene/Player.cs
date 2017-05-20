using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]//この属性を使ってインスペクター上で表示
public class Player{
	public string playerName;
	public int playerID;
	public string playerDesc; //プレイヤーの状態や現在地を文章で用意しておく。いらないかも
	public int playerLife; //プレイヤーのHP
	public int playerInfection; //プレイヤーの感染率
	public int playerPower; //プレイヤーの基礎攻撃力
	public int playerSpeed; //プレイヤーの移動速度
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

	public Player(string name, int id, string desc, int life, int infection, int power, int speed, PlayerHealth health, PlayerStatus status, List<Item> items)
    {
        playerName = name;
        playerID = id;
        playerDesc = desc;
        playerLife = life;
        playerPower = power;
        playerSpeed = speed;
        playerHealth = health;
		playerStatus = status;
		playerItems = items;
    }

}
