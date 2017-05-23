using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillDataBase : MonoBehaviour {

    public List<Skill> skills = new List<Skill>();
	public List<Skill> mySkills = new List<Skill>();
    public void SetInitialize()    
    {   
		skills.Clear();
        //skills.Add(new Skill(null, 0, null, 0, Skill.SkillType.Other));//空用のダミーオブジェクト
		skills.Add(new Skill("集中力強化 LV1", 1, "攻撃力2倍。集中力を高めることで、的確な射撃を行えるようになる。", 2.0f, 0 ,3000, Skill.SkillType.AttackUP));
		skills.Add(new Skill("体力増強 LV1", 2, "防御力2倍。体力の増強により、敵の攻撃をより耐えしのげるようになる", 2.0f, 0, 3000, Skill.SkillType.DefenceUP));
		skills.Add(new Skill("脚力強化 LV1", 3, "スピード1.5倍。脚力の増強により、移動速度が速くなる", 1.5f, 0 ,3000, Skill.SkillType.SpeedUP));
		skills.Add(new Skill("二段ジャンプ", 4, "二段ジャンプが可能になる。", 0, 0 ,10000, Skill.SkillType.IncreaseAction));
		skills.Add(new Skill("ダッシュ", 5, "cキーでダッシュが可能になる", 0 ,0 ,10000, Skill.SkillType.IncreaseAction));
		skills.Add(new Skill("空中ダッシュ", 6, "空中でのダッシュが可能になる。", 0 ,5 ,10000, Skill.SkillType.IncreaseAction));
		skills.Add(new Skill("免疫強化Lv1", 7, "感染率、侵食率の増加を低減。自己免疫力を強化し、感染の進行を遅らせる", 0 ,0 ,30000, Skill.SkillType.IncreaseAction));
		skills.Add(new Skill("完全抗体", 8, "感染率、侵食率の増加を完全に抑える", 0 ,7 ,999999, Skill.SkillType.InfectionStop));
		skills.Add(new Skill("実施試験", 9, "相手へのダメージ分リサーチポイントを得ることができる。", 0 ,0 ,30000, Skill.SkillType.InfectionStop));
		skills.Add(new Skill("耐久試験", 10, "自分が受けたダメージ分x10のリサーチポイントを得ることができる。", 0 ,0 ,30000,Skill.SkillType.InfectionStop));
		skills.Add(new Skill("研究力 Lv1", 11, "研究効率を上げることで、リサーチポイントがより溜まりやすくなる", 0 ,0 ,30000, Skill.SkillType.InfectionStop));
    }

	public void GetSkill(Skill skill){
		mySkills.Add(skill);
	}
}
