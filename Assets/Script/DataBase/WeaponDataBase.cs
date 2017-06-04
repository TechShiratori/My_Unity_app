using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDataBase : MonoBehaviour {

    public List<Weapon> weapons = new List<Weapon>();
    public void SetInitialize()    
    {   
        weapons.Clear();
        weapons.Add(new Weapon("ハンドガン", 0, "HandGun","護身用のハンドガン。威力はあまり高くない",10, 10, 0, 0, true,Weapon.WeaponTypes.SingleShot));
        weapons.Add(new Weapon("アサルトライフル", 0,"AssaultRifle","標準的な突撃銃。連射力、威力共に優れている", 20, 1, 300, 999, false,Weapon.WeaponTypes.AssaultRifle));
        weapons.Add(new Weapon("ショットガン", 0,"ShotGun", "近距離で高い威力を発揮する銃。しかし連射力が低いのが欠点",50, 20, 30, 99, false,Weapon.WeaponTypes.Shotgun));
        weapons.Add(new Weapon("マグナム", 0,"Magnum", "取り回しが難しいが威力が非常に高い銃。しかし連射力が低いのが欠点",100, 15, 6, 99, false,Weapon.WeaponTypes.Shotgun));
    }
}
