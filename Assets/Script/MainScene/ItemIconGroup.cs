using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemIconGroup : MonoBehaviour {
	[SerializeField] private GameObject itemPrefab;
	private RawImage m_img;
	private string itemName;
	private List<GameObject> m_itemList = new List<GameObject>();
	private List<string> m_itemNameList = new List<string>();
	public void CreateItems(List<string> m_itemIcon){
		for(int i = 0; i < m_itemIcon.Count; i++){
			ItemIcon test = new ItemIcon();
			GameObject sponeItem = Instantiate (itemPrefab) as GameObject;
			m_itemList.Add(sponeItem);
			sponeItem.transform.parent = transform;
			m_img = sponeItem.transform.FindChild("Image").gameObject.GetComponent<RawImage>();
			itemName = "Textures/" + m_itemIcon[i];
			itemName = itemName.Replace("(Clone)","");
			//Debug.Log(itemName);
			m_img.texture = Resources.Load(itemName) as Texture2D;
			m_itemNameList.Add(m_itemIcon[i]);
			//test.SetItemIcon(m_itemIcon[i]);
		}
	}

	public void UpdateItems(int m_keyPosition){
		foreach ( Transform n in transform )
			{
			GameObject.Destroy(n.gameObject);
			}
		//CreateItems(m_itemNameList);
	}

	public void SetCursor(int m_keyPosition){
		if(m_itemList.Count >= m_keyPosition){
			Debug.Log(m_itemList[m_keyPosition - 1]);
			//GameObject CursorObj = m_itemList[m_keyPosition - 1].transform.FindChild("Cursor").gameObject;
			for(int i = 0; i < m_itemList.Count ; i++){
				GameObject CursorObj = m_itemList[i].transform.FindChild("Cursor").gameObject;
				if(i == (m_keyPosition - 1)){
					CursorObj.SetActive(true);
				}else{
					CursorObj.SetActive(false);
				}
			}
		}
	}
	public void UseItem(int m_keyPosition){
		if(m_itemList.Count >= m_keyPosition){
			m_itemList.RemoveAt(m_keyPosition-1);
			if(m_keyPosition != 1){
				SetCursor(m_keyPosition - 1);
				UpdateItems(m_keyPosition - 1);
			}else{
				SetCursor(m_keyPosition);
				UpdateItems(m_keyPosition - 1);
			}
			
		}
	}
}
