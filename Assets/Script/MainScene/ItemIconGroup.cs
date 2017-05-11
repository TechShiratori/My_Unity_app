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
	private List<GameObject> m_itemObjList;
	private List<string> m_itemNameList;
	public void CreateItems(List<string> itemNameList){
		UpdateItems(itemNameList);

		for(int i = 0; i < itemNameList.Count; i++){
			if(itemNameList != null){
				m_itemGroupName = "ItemIcon_" + (i+1).ToString();
				m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
				m_img = m_itemGroup.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
				itemName = "Textures/" + itemNameList[i];
				itemName = itemName.Replace("(Clone)","");
				m_img.texture = Resources.Load(itemName) as Texture2D;
			}else{
				m_itemGroupName = "ItemIcon_" + (i+1).ToString();
				m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
				m_img = m_itemGroup.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
				m_img.texture = null;
			}
		}
		m_itemNameList = itemNameList;
	}

	public void UpdateItems(List<string> m_itemNameList){

		for(int i = 0; i < m_itemNameList.Count; i++){
			if(m_itemNameList.Count < 10){
				m_itemNameList.Add(null);
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
		m_itemNameList.RemoveAt(m_keyPosition-1);
		//m_itemNameList.Add(null);
		if(m_itemNameList[m_keyPosition] != null){
				SetCursor(m_keyPosition);
				//UpdateItems(m_keyPosition - 1);
		}else if(m_keyPosition == 1 || m_itemNameList[m_keyPosition] == null){
				SetCursor(m_keyPosition);
				//UpdateItems(m_keyPosition - 1);
		}
	}
}
