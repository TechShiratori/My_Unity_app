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
	private List<GameObject> m_itemList = new List<GameObject>();
	private List<string> m_itemNameList = new List<string>();
	private int m_itemListCount;
	public void CreateItems(List<string> m_itemIcon){
		for(int i = 0; i < m_itemIcon.Count; i++){

			if(m_itemIcon.Count < 10){
				m_itemIcon.Add(null);
			}

			if(m_itemIcon != null){
				m_itemGroupName = "ItemIcon_" + (i+1).ToString();
				m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
				m_img = m_itemGroup.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
				itemName = "Textures/" + m_itemIcon[i];
				itemName = itemName.Replace("(Clone)","");
				m_img.texture = Resources.Load(itemName) as Texture2D;
				m_itemNameList.Insert(i,m_itemIcon[i]);
			}else{
				m_itemGroupName = "ItemIcon_" + (i+1).ToString();
				m_itemGroup = transform.FindChild(m_itemGroupName).gameObject;
				m_img = m_itemGroup.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
				m_img.texture = null;
			}
			//GameObject sponeItem = Instantiate (itemPrefab) as GameObject;
			//m_itemList.Add(sponeItem);
			//sponeItem.transform.parent = transform;
			//m_img = sponeItem.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
			//itemName = "Textures/" + m_itemIcon[i];
			//itemName = itemName.Replace("(Clone)","");
			//Debug.Log(itemName);
			//m_img.texture = Resources.Load(itemName) as Texture2D;
			//m_itemNameList.Add(m_itemIcon[i]);
			//test.SetItemIcon(m_itemIcon[i]);
		}
		m_itemListCount = m_itemIcon.Count;
	}

	public void UpdateItems(int m_keyPosition){
		/*
		foreach ( Transform n in transform )
			{
			GameObject.Destroy(n.gameObject);
			}
		*/
		//CreateItems(m_itemNameList);
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
		m_itemNameList.Add(null);
		Debug.Log(m_itemNameList.Count);
			if(m_keyPosition != 1){
				SetCursor(m_keyPosition - 1);
				//UpdateItems(m_keyPosition - 1);
			}else{
				SetCursor(m_keyPosition);
				//UpdateItems(m_keyPosition - 1);
			}
	}
}
