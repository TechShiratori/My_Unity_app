using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill
{
    public string skillName;        //名前
    public int skillID;             //スキルID
    public string skillDesc;        //スキルの説明文
    public string skillIconName;            //アイコン参照用の名前
    public Texture2D skillIcon;     //アイコン
    public double skillPower;          //効果の値。
    public int needSkillID;			//必要の前提となるスキルID
    public int needExp;             //獲得に必要なEXP
    public SkillType skillType;     //スキルの種類

    //アイテムタイプも同じくenum      
    public enum SkillType
    {
        AttackUP,
        DefenceUP,
        SpeedUP,
        HpUP,
        InfectionUP,
        InfectionStop,
        IncreaseAction,
        Other,
    }
    //ここでリスト化時に渡す引数をあてがいます   
    public Skill(string name, int id, string desc, string iconName,float power, int needSkill, int exp, SkillType type)
    {
        skillName = name;
        skillID = id;
        skillIconName = iconName;
        //アイコンはnameとイコールにするのでアイコンがあるパス＋nameで取ってきます    
        //skillIcon = Resources.Load<Texture2D>("Textures/" + name);
        skillDesc = desc;
        skillPower = power;
        needSkillID = needSkill;
        needExp = exp;
        skillType = type;
    }
    public Skill()
    {
        
    }
}
