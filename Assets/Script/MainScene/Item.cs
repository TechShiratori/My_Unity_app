using UnityEngine;
using System.Collections;


[System.Serializable]//この属性を使ってインスペクター上で表示
public class Item 
{
    public string itemName;        //名前
    public int itemID;             //アイテムID
    public string itemDesc;        //アイテムの説明文
    public Texture2D itemIcon;     //アイコン
    public int itemPower;          //攻撃力、アイテム回復量、アイテム持続時間など
    public int itemAttackSpeed;    //武器専用、攻撃速度
    public ItemType itemType;      //アイテムの種類

//アイテムタイプも同じくenum      
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
//ここでリスト化時に渡す引数をあてがいます   
public Item(string name, int id, string desc, int power, int speed, ItemType type)
    {
        itemName = name;
        itemID = id;
//アイコンはnameとイコールにするのでアイコンがあるパス＋nameで取ってきます    
        itemIcon = Resources.Load<Texture2D>("Textures/" + name);
        itemDesc = desc;
        itemPower = power;
        itemAttackSpeed = speed;
        itemType = type;
    }

}