using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EffectDataBase : MonoBehaviour
{
	
//リスト化をして下のvoid Start内でリストに値を追加
public List<Effect> effects = new List<Effect>();
	public void SetDataBase()
    {   
        effects.Add(new Effect(null,0,null,Effect.EffectType.Nothing,Effect.EffectType.Nothing,0,0));//空用のダミーオブジェクト
        effects.Add(new Effect("EnemyDamage",1,"敵の攻撃によるダメージ",Effect.EffectType.ChangeLife,Effect.EffectType.Nothing,30,0));
		effects.Add(new Effect("RecoverHP30",2,"アイテムによるHP回復。30%",Effect.EffectType.ChangeLife,Effect.EffectType.Nothing,30,0));
		effects.Add(new Effect("RecoverHP100",3,"アイテムによるHP回復。100%",Effect.EffectType.ChangeLife,Effect.EffectType.Nothing,100,0));
		effects.Add(new Effect("RecoverInfection30",4,"アイテムによる感染率回復。30%",Effect.EffectType.ChangeInfection,Effect.EffectType.Nothing,30,0));
		effects.Add(new Effect("RecoverErosion30",5,"アイテムによる侵食率回復。30%",Effect.EffectType.ChangeInfection,Effect.EffectType.Nothing,30,0));
		effects.Add(new Effect("AttackUP",6,"攻撃力倍加。感染率10%上昇",Effect.EffectType.ChangeAttack,Effect.EffectType.ChangeInfection,100,10));
		effects.Add(new Effect("DeffenceUP",7,"HP減少&感染率上昇率半減。感染率10%上昇",Effect.EffectType.ChangeDeffence,Effect.EffectType.ChangeInfection,50,10));
		effects.Add(new Effect("SpeedUP",8,"速度1.5倍。感染率10%上昇",Effect.EffectType.ChangeSpeed,Effect.EffectType.ChangeInfection,50,10));
    }
}