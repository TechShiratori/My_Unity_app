using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemMenuController : MonoBehaviour {
	private int keyPosition;
	private int count;
	private string selectButtonName;
	private string itemPositionName;
	private GameObject selectButton;
	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private GameObject m_cursor;
	[SerializeField] private ItemIconGroup m_itemIconGroup;
	[SerializeField] private ActSceneContoller m_actSceneController;

	// Use this for initialization
	void Start () {
		float dx = Time.deltaTime * 1f;
		keyPosition = 1;
		count = 0;
//		m_cursor.transform.position = new Vector2(10,-10);
		
		//SetItemIcon(m_actSceneController.itemList);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftArrow) && count > 8){
			switch(keyPosition){
				case 1:
					keyPosition = 5;
					break;
				case 6:
					keyPosition = 10;
					break;
				default:
					keyPosition --;
					break;
			}
			Debug.Log(keyPosition);
			SelectCursor(keyPosition);
		}
		else if(Input.GetKey(KeyCode.RightArrow) && count > 8){
			switch(keyPosition){
				case 5:
					keyPosition = 1;
					break;
				case 10:
					keyPosition = 6;
					break;
				default:
					keyPosition++;
					break;
			}
			Debug.Log(keyPosition);
			SelectCursor(keyPosition);
		}
		else if((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) && count > 8){
			if(keyPosition <= 5){
				keyPosition += 5;
			}else{
				keyPosition -= 5;
			}
			Debug.Log(keyPosition);
			SelectCursor(keyPosition);
		}else if (Input.GetKey(KeyCode.Z) && count > 8){
			count = 0;
			m_itemIconGroup.UseItem(keyPosition);
		}



		count++;

	}
	public void Open(){
		Debug.Log(m_actSceneController.itemListName[0]);
		m_itemIconGroup.CreateItems(m_actSceneController.itemListName);
	}
	private void SelectCursor(int m_select){
		count = 0;
		m_itemIconGroup.SetCursor(m_select);
	}

	private void SetItemIcon(List<GameObject> m_itemIcon){
		for(int i = 0; i <= m_itemIcon.Count; i++){
			//itemPositionName = "ItemIcon_" + (i+1).ToString();
			//GameObject itemPosition = GameObject.Find(itemPositionName);
			//GameObject sponeItem = Instantiate (itemPrefab) as GameObject;
			//Image img = GameObject.Find("Canvas/Panel/***").GetComponent<Image>();
			//Image img = sponeItem.GetComponent<Image>();
			//Texture2D tex2d = Resources.Load("Textures/Aidkit") as Texture2D;
			//img.material.mainTexture = Resources.Load("Textures/Aidkit") as Texture2D;
			//sponeItem.transform.position = itemPosition.transform.position;
		}
	}
}
