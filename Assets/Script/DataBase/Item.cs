using UnityEngine;
using System.Collections;


[System.Serializable]//この属性を使ってインスペクター上で表示
public class Item 
{
    public string itemName;        //名前
    public int itemID;             //アイテムID
    public string itemDesc;        //アイテムの説明文
    public int itemPower;          //効果の値。攻撃力、アイテム回復量、アイテム持続時間、経験値など
    public int itemAttackSpeed;    //武器専用、攻撃速度
    public ItemType itemType;      //アイテムの種類
    public Effect itemEffect;
    public enum ItemType
    {
        Weapon,
		RecoverItem,
		EventItem,
		EndingItem,
		PowerUpItem,
		SupportItem,
		ExpItem,
		Empty,
    }
    
    public Item(string name, int id, string desc,Effect effect, int power, int speed, ItemType type)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
        itemEffect = effect;
        itemPower = power;
        itemAttackSpeed = speed;
        itemType = type;
    }
    public Item(){

    }

}