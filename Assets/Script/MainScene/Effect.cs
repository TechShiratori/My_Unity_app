using UnityEngine;
using System.Collections;


[System.Serializable]//この属性を使ってインスペクター上で表示
public class Effect
{
    public string effectName;        //名前
    public int effectID;             //エフェクトID
    public string effectDesc;        //エフェクトの説明文
    public EffectType effectType_1;   //エフェクトの効果_1
    public EffectType effectType_2;   //エフェクトの効果_2
    public int effectPower_1;   //エフェクト1の効果の値。攻撃力、アイテム回復量、アイテム持続時間、経験値など
	public int effectPower_2;	　//エフェクト2の効果の値。攻撃力、アイテム回復量、アイテム持続時間、経験値など

    public enum EffectType
    {
        Nothing,
        AttackDamage,       //敵にダメージを与える（攻撃専用）
		ChangeLife,         //プレイヤーのHPの増減
		ChangeInfection,    //感染率の増減
		ChangeAttack,		//攻撃力変化
		ChangeDeffence,		//防御力変化
		ChangeSpeed,		//スピード変化
		Poison,				//毒状態
		Bind,				//拘束状態
		Special,            //上記以外の特殊な変化
    }

//ここでリスト化時に渡す引数をあてがいます   
public Effect(string name, int id, string desc, EffectType effect_1, EffectType effect_2, int power_1, int power_2)
    {
        effectName = name;
        effectID = id;
        effectDesc = desc;
        effectType_1 = effect_1;
        effectType_2 = effect_2;
        effectPower_1 = power_1;
		effectPower_2 = power_2;	
    }

}