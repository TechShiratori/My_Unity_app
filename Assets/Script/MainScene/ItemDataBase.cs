using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDataBase : MonoBehaviour
{
    //リスト化をして下のvoid Start内でリストに値を追加
    public List<Item> items = new List<Item>();
    //[SerializeField]private EffectDataBase database;

/* 
    void Start()    
    {   
        database.SetDataBase();
        items.Add(new Item(null, 0, null, database.effects[0], 0, 0, Item.ItemType.Empty));//空用のダミーオブジェクト
        items.Add(new Item("Bantage", 1, "傷の手当てに使う包帯。HPを30%回復する", database.effects[2], 30, 0, Item.ItemType.RecoverItem));
        items.Add(new Item("Aidkit", 2, "傷の手当てに医療器具。HPを100%回復する", database.effects[3], 30, 0, Item.ItemType.RecoverItem));
    }
    */
    public void SetDataBase(EffectDataBase database)    
    {   
        items.Add(new Item(null, 0, null, database.effects[0], 0, 0, Item.ItemType.Empty));//空用のダミーオブジェクト
        items.Add(new Item("Bantage", 1, "傷の手当てに使う包帯。HPを30%回復する", database.effects[2], 30, 0, Item.ItemType.RecoverItem));
        items.Add(new Item("Aidkit", 2, "傷の手当てに医療器具。HPを100%回復する", database.effects[3], 30, 0, Item.ItemType.RecoverItem));
    }
}