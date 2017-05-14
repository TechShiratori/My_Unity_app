using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconGroup : MonoBehaviour {
	[SerializeField] private GameObject itemPrefab;
	
	private RawImage m_img;
	private string itemName;
	private GameObject m_itemGroup;
	private string m_itemGroupName;
	private GameObject CursorObj;
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

	public void SetCursor(int m_keyPosition){
			for(int i = 0; i < 10 ; i++){
				m_itemGroupName = "ItemIcon_" + (i + 1).ToString();
				m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
				CursorObj = m_itemGroup.transform.FindChild("Cursor").gameObject;
				if(i + 1 == m_keyPosition){
					CursorObj.SetActive(true);
				}else{
					CursorObj.SetActive(false);
				}
			}
	}
	public void UseItem(int m_keyPosition){

		m_itemGroupName = "ItemIcon_" + m_keyPosition.ToString();
		m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
		CursorObj = m_itemGroup.transform.FindChild("Cursor").gameObject;
		m_img = m_itemGroup.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
		m_img.texture = null;
		//GameObject itemObj = transform.Find(m_itemNameList[m_keyPosition-1]).gameObject;
		m_backPack.RemoveAt(m_keyPosition-1);
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
}
