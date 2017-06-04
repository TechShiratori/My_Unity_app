using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//この属性を使ってインスペクター上で表示
public class Weapon
{
    public string weaponName;
    public int weaponID;
	public string weaponIconName;
	public string weaponDesc;
    public int weaponPower; //武器攻撃力
    public int weaponSpeed; //武器攻撃間隔
    public int remainingBullet; //残弾数
	public int maxRemainingBullet; //最大残弾数　0なら無限
    public bool isObtained; //入手したか
	public WeaponTypes weaponType; //武器の種類
	public enum WeaponTypes
    {
        SingleShot,
		AssaultRifle,
		Shotgun,
    }
	public Weapon(string name, int id, string iconName,string desc,int power, int speed, int remaining, int maxRemaing, bool obtained, WeaponTypes type){
		weaponName = name;
		weaponID = id;
		weaponIconName = iconName;
		weaponDesc = desc;
		weaponPower = power;
		weaponSpeed = speed;
		remainingBullet = remaining;
		maxRemainingBullet = maxRemaing;
		isObtained = obtained;
		weaponType = type;
	}

	public Weapon(){

	}
}
