using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//この属性を使ってインスペクター上で表示
public class ImportantItem{

    public string importantItemName;        //名前
    public int importantItemID;             //アイテムID
	public string importantItemIconName;        //名前
    public string importantItemDesc;        //アイテムの説明文

	public ImportantItem(string name, int id, string iconName,string desc){
		importantItemName = name;
		importantItemID = id;
		importantItemIconName = iconName;
		importantItemDesc = desc;
	}
	public ImportantItem(){

	}
}
