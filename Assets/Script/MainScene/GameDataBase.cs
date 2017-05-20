using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDataBase : MonoBehaviour {

public ItemDataBase itemDatabase;
public EffectDataBase effectDatabase;
public PlayerDataBase playerDatabase;

	void Start () {
		//playerDatabase.SetInitialize();
		effectDatabase.SetDataBase();
		itemDatabase.SetDataBase(effectDatabase);
	}
}
