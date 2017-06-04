using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImportantItemDataBase : MonoBehaviour {

    public List<ImportantItem> ImportantItems = new List<ImportantItem>();
    public void SetInitialize()    
    {   
        ImportantItems.Clear();
        ImportantItems.Add(new ImportantItem("カードキー", 0,"PassCard", "標準的な研究員が持つことができるカードキー。一部の扉を開くことができる"));
       	ImportantItems.Add(new ImportantItem("ブループリント", 0, "BluePrint","重要な研究情報がまとめられている資料"));
        ImportantItems.Add(new ImportantItem("レコーダー", 0,"Recoder", "機密事項の音声記録が保存されているテープ"));
		ImportantItems.Add(new ImportantItem("マスターキー", 0,"MasterKey", "限られた職員のみ所持ができるカードキー。全ての扉を開くことができる"));
    }
}
