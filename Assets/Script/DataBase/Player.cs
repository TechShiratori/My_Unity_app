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
	public List<Weapon> playerWeapons;
	public Weapon equipWeapon; //現在装備してる武器
	public int playerExp;

	public Player(string name, int id, string desc, int life, int maxlife, int infection, int erosion ,int power, int speed, PlayerHealth health, PlayerStatus status,string save, List<Item> items, List<Skill> skills,List<Weapon> weapons, Weapon equip,int exp)
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
		playerWeapons = weapons;
		equipWeapon = equip;
		playerSkill = skills;
		playerExp = exp;
    }
	public Player(){

	}
	public Player SetInitialize(Player player)	//初期のプレイヤーデータ。最初から始めた時用。武器はあらかじめ所持してるが直す予定
    {
		List<Item> initializeItems = new List<Item>();
		List<Skill> initializeSkill = new List<Skill>();
		List<Weapon> initializeWeapons = new List<Weapon>();
		initializeWeapons.Add(new Weapon("ハンドガン", 0, "HandGun","護身用のハンドガン。威力はあまり高くない",10, 20, 0, 0, true,Weapon.WeaponTypes.SingleShot));
		initializeWeapons.Add(new Weapon("アサルトライフル", 1,"AssaultRifle","標準的な突撃銃。連射力、威力共に優れている", 20, 5, 100, 999, false,Weapon.WeaponTypes.AssaultRifle));
        initializeWeapons.Add(new Weapon("ショットガン", 2,"ShotGun", "近距離で高い威力を発揮する銃。しかし連射力が低いのが欠点",50, 35, 10, 99, false,Weapon.WeaponTypes.Shotgun));
        initializeWeapons.Add(new Weapon("マグナム", 3,"Magnum", "取り回しが難しいが威力が非常に高い銃。弾が希少なのが欠点",100, 25, 6, 99, false,Weapon.WeaponTypes.Shotgun));
		var setequip = initializeWeapons[0];
		player = new Player("リゼ=アルコット",0,"裏切りの科学者",100,100,0,0,10,10,Player.PlayerHealth.Fine,Player.PlayerStatus.None,"",initializeItems,initializeSkill,initializeWeapons,setequip,0);
		return player;
	}

	public Player SetCurrentPlayer(Player player)	//初期のプレイヤーデータ。最初から始めた時用
    {
		return player;
	}
}
