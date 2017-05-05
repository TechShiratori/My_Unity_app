using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMenuController : MonoBehaviour {
	private int keyPosition;
	private int count;
	private string selectButtonName;
	private string itemPositionName;
	private GameObject selectButton;
	[SerializeField] private GameObject itemPrefab;
	[SerializeField] private GameObject m_cursor;
	[SerializeField] private ActSceneContoller m_actSceneController;

	// Use this for initialization
	void Start () {
		float dx = Time.deltaTime * 1f;
		keyPosition = 1;
		count = 0;
		m_cursor.transform.localPosition = new Vector2(55,-10);
		SetItemIcon(m_actSceneController.itemList);
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
		}
		count++;

	}

	private void Open(GameObject m_MainMenu,GameObject m_ItemMenu){

		//SetItemIcon(m_ItemMenu);


	}
	private void SelectCursor(int m_select){
		count = 0;
		selectButtonName = "ItemIcon_" + keyPosition.ToString();
		selectButton = GameObject.Find(selectButtonName);
		m_cursor.transform.position = new Vector2(selectButton.transform.position.x,selectButton.transform.position.y + 5);
	}

	private void SetItemIcon(List<GameObject> m_itemIcon){
		for(int i = 0; i <= m_itemIcon.Count; i++){
			itemPositionName = "ItemIcon_" + (i+1).ToString();
			GameObject itemPosition = GameObject.Find(itemPositionName);
			GameObject sponeItem = Instantiate (itemPrefab) as GameObject;
			sponeItem.transform.position = itemPosition.transform.position;
		}
	}
}
