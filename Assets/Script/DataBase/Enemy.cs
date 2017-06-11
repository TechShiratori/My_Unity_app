using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy{

	public string enemyName;
	public int enemyID;
	public string enemyDesc; //敵の内容を文章で用意しておく。いらないかも
	public int enemyLife; //敵のHP
	public int enemyPower; //敵の攻撃力
	public int enemySpeed; //敵の移動速度
	public int enemyEXP;  //経験値
	public Item enemyItem; //ドロップアイテム
	public float itemDropProbability; //アイテムドロップ確率
	public EnemyStatus enemyStatus;
	public enum EnemyStatus	//敵の現在ステータス(状態異常と行動指針)
	{
		None,
		Wait,		//待機
		Search,		//索敵
		Trace,		//追跡
		Charge,		//攻撃後などの硬直時
		Attack,		//攻撃
		Stan,		//スタン状態
		Dead,		//死亡
		Other
	}

	public Enemy(string name, int id, string desc, int life, int power, int speed, int exp, Item item, int dropProbabilyty, EnemyStatus status)
    {
        enemyName = name;
        enemyID = id;
        enemyDesc = desc;
        enemyLife = life;
        enemyPower = power;
        enemySpeed = speed;
		enemyEXP = exp;
		enemyItem = item;
		itemDropProbability = dropProbabilyty;
		enemyStatus = status;
    }

	public Enemy(){
		
	}
}
