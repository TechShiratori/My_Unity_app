using UnityEngine;
using System.Collections;


[System.Serializable]//この属性を使ってインスペクター上で表示
public class Item 
{
    public string itemName;        //名前
    public int itemID;             //アイテムID
    public string itemDesc;        //アイテムの説明文
    public Texture2D itemIcon;     //アイコン
    //public ItemEffect itemEffect_1;   //アイテムの効果_1
    //public ItemEffect itemEffect_2;   //アイテムの効果_2
    public int itemPower;          //効果の値。攻撃力、アイテム回復量、アイテム持続時間、経験値など
    public int itemAttackSpeed;    //武器専用、攻撃速度
    public ItemType itemType;      //アイテムの種類
    public EffectDataBase EffectDataBase;
    public Effect itemEffect;
    public Effect.EffectType itemEffect_1;
    public Effect.EffectType itemEffect_2;
/* 
    public enum ItemEffect
    {
        Nothing,
        AttackDamage,       //ダメージを与える（武器専用）
		ChangeLife,         //HPの増減
		ChangeInfection,    //感染率の増減
		ChangeStatus,       //状態変更（毒、麻痺など）
		ChangeParamater,　　//能力変化（速度上昇、攻撃力増加など）
		Special,            //上記以外の特殊な変化
    }
*/
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
public Item(string name, int id, string desc,Effect effect, int power, int speed, ItemType type)
    {
        itemName = name;
        itemID = id;
//アイコンはnameとイコールにするのでアイコンがあるパス＋nameで取ってきます    
        itemIcon = Resources.Load<Texture2D>("Textures/" + name);
        itemDesc = desc;
        itemEffect = effect;
        itemPower = power;
        itemAttackSpeed = speed;
        itemType = type;
    }

}