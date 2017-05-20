using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconGroup : MonoBehaviour {
	[SerializeField] private ActSceneContoller m_actSceneController;
	private RawImage m_img;
	private GameObject m_itemGroup;
	private string m_itemGroupName;
	private GameObject m_CursorObj;
	private List<Item> m_backPack;
	public void CreateItems(List<Item> backPack){
		UpdateItems(backPack);

		for(int i = 0; i < backPack.Count; i++){
			if(backPack[i] != null){
				m_itemGroupName = "ItemIcon_" + (i+1).ToString();
				m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
				m_img = m_itemGroup.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
				m_img.texture = backPack[i].itemIcon;
			}else{
				m_itemGroupName = "ItemIcon_" + (i+1).ToString();
				m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
				m_img = m_itemGroup.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
				m_img.texture = null;
			}
		}
		m_backPack = backPack;
	}

	public void UpdateItems(List<Item> itemName){

		for(int i = 0; i < itemName.Count; i++){
			if(itemName.Count < 10){
				itemName.Add(null);
			}
		}
	}

	public void SetCursor(int keyPosition){
			for(int i = 0; i < 10 ; i++){
				m_itemGroupName = "ItemIcon_" + (i + 1).ToString();
				m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
				m_CursorObj = m_itemGroup.transform.FindChild("Cursor").gameObject;
				if(i + 1 == keyPosition){
					m_CursorObj.SetActive(true);
				}else{
					m_CursorObj.SetActive(false);
				}
			}
	}
	public void UseItem(int keyPosition){

		m_itemGroupName = "ItemIcon_" + keyPosition.ToString();
		m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
		m_CursorObj = m_itemGroup.transform.FindChild("Cursor").gameObject;
		m_img = m_itemGroup.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
		m_img.texture = null;
		//GameObject itemObj = transform.Find(m_itemNameList[m_keyPosition-1]).gameObject;
		Debug.Log(m_backPack[keyPosition-1].itemDesc);

//		m_actSceneController.ActiveEffect(m_backPack[keyPosition-1],m_backPack[keyPosition-1].itemEffect_1,m_backPack[keyPosition-1].itemEffect_2);
		if(m_backPack[keyPosition-1].itemType == Item.ItemType.RecoverItem){
			m_actSceneController.ActiveEffect(m_backPack[keyPosition-1].itemEffect);
		}
		m_backPack.RemoveAt(keyPosition-1);
		m_backPack.Add(null);

		/* 
		if(m_backPack[m_keyPosition-1] != null){
				SetCursor(m_keyPosition);
				//UpdateItems(m_keyPosition - 1);
		}else if(m_keyPosition == 1 || m_backPack[m_keyPosition-1] == null){
				SetCursor(m_keyPosition);
				//UpdateItems(m_keyPosition - 1);
		}
		*/
	}

	public void ItemEffect(Item item){
		if(item.itemType == Item.ItemType.RecoverItem){
			//m_actSceneController.ChangeStatus(item);
		}
	}
}
