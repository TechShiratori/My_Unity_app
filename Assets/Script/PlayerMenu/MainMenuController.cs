using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
public class MainMenuController : MonoBehaviour {
	private int keyPosition;
	private int count;
	private string selectButtonName;
	private string selectSceneName;
	private GameObject selectButton;
	private GameObject selectMenu;
	private enum MenuButton{
		Main = 0,
		Weapon,
		Item,
		Skill,
		Option
	}
	[SerializeField] private GameObject m_playerMenu;
	[SerializeField] private GameObject m_cursor;
	[SerializeField] private ItemMenuController m_itemMenuController;
	[SerializeField] private ActSceneContoller m_act;
	[SerializeField] private Text m_pointText;
	[SerializeField] private Text m_playerController;
	private MenuButton m_menuButton;

	// Use this for initialization
	void Start () {
		float dx = Time.deltaTime * 1f;
		keyPosition = 1;
		count = 0;
		selectSceneName = "Weapon";
		selectMenu = GameObject.Find(selectSceneName);
		m_cursor.transform.localPosition = GameObject.Find("MainMenuButton_1").transform.localPosition;
	}
	
	public void Open(){
		m_pointText.text = "SearchPoint:" + m_act.player.playerExp.ToString();

		if(Input.GetKey(KeyCode.UpArrow) && count > 8){
			if(keyPosition !=1){
				keyPosition--;
			}else{
				keyPosition = 4;
			}
			SelectCursor(keyPosition);
			selectSceneName = m_menuButton.ToString();
		}
		else if(Input.GetKey(KeyCode.DownArrow) && count > 8){
			if(keyPosition !=4){
				keyPosition++;
			}else{
				keyPosition = 1;
			}
			SelectCursor(keyPosition);
			selectSceneName = m_menuButton.ToString();
		}
		else if(Input.GetKey(KeyCode.Z) && count > 8){
			var playerMenuController = m_playerMenu.GetComponent<PlayerMenuController>();
			playerMenuController.SelectMenu(selectSceneName);
			count = 0;
		}
		else if(Input.GetKey(KeyCode.X) && count > 8){
			var playerMenuController = m_playerMenu.GetComponent<PlayerMenuController>();
			playerMenuController.SelectMenu("NotActive");
		}
		count++;

	}
	private void SelectCursor(int m_select){
		count = 0;
		m_menuButton = (MenuButton) keyPosition;
		selectButtonName = "MainMenuButton_" + m_select.ToString();
		selectButton = GameObject.Find(selectButtonName);
		m_cursor.transform.localPosition = selectButton.transform.localPosition;
	}
}
