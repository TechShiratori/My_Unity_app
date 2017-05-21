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
	[SerializeField] private GameObject m_playerMenuController;
	[SerializeField] private ItemIconGroup m_itemIconGroup;

	[SerializeField] private ActSceneContoller m_actSceneController;

	// Use this for initialization
	void Start () {
		float dx = Time.deltaTime * 1f;
		keyPosition = 1;
		count = 0;
	}
	
	public void Open(){
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
		}else if (Input.GetKey(KeyCode.X) && count > 8){
			count = 0;
			string mainMenu = "Main";
			var playerMenu = m_playerMenuController.GetComponent<PlayerMenuController>();
			playerMenu.SelectMenu(mainMenu);
		}
		
		if(m_actSceneController.backPack != null){
			m_itemIconGroup.CreateItems(m_actSceneController.backPack);
		}
		count++;
	}
	private void SelectCursor(int m_select){
		count = 0;
		m_itemIconGroup.SetCursor(m_select);
	}

}
