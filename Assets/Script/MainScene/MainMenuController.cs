﻿using System.Collections;
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
	private GameObject thisMenu;
	private enum MenuButton{
		Main = 0,
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
	private MenuButton ex;

	// Use this for initialization
	void Start () {
		float dx = Time.deltaTime * 1f;
		keyPosition = 1;
		count = 0;
		selectButtonName = "MainMenuButton_1";
		selectButton = GameObject.Find(selectButtonName);
		selectSceneName = "Item";
		selectMenu = GameObject.Find(selectSceneName);
		m_cursor.transform.localPosition = new Vector2(0,selectButton.transform.localPosition.y);
	}
	
	// Update is called once per frame
	void Update () {
		/* 
		if(Input.GetKey(KeyCode.UpArrow) && count > 8){
			if(keyPosition !=1){
				keyPosition--;
			}else{
				keyPosition = 3;
			}
			SelectCursor(keyPosition);
			selectSceneName = ex.ToString() + "Menu";
		}
		else if(Input.GetKey(KeyCode.DownArrow) && count > 8){
			if(keyPosition !=3){
				keyPosition++;
			}else{
				keyPosition = 1;
			}
			SelectCursor(keyPosition);
			selectSceneName = ex.ToString() + "Menu";
		}
		else if(Input.GetKey(KeyCode.Z) && count > 8){
			for(int i = 0; i < m_playerMenu.transform.childCount; i++){
				if(selectSceneName == m_playerMenu.transform.GetChild(i).gameObject.name){
					selectMenu = m_playerMenu.transform.GetChild(i).gameObject;
				}
			}
			count = 0;
			Debug.Log(m_act.itemListName[0]);
			selectMenu.SetActive(true);
			thisMenu = this.gameObject;
			thisMenu.SetActive(false);
			if(selectSceneName == "ItemMenu"){
				m_itemMenuController.Open();
			}else if (selectSceneName == "SkillMenu"){
				Debug.Log("Skill");
			}
		}
		count++;
		m_pointText.text = "SearchPoint:" + m_act.AllPoint.ToString();
		*/
	}
	public void Open(){
		m_pointText.text = "SearchPoint:" + m_act.AllPoint.ToString();

		if(Input.GetKey(KeyCode.UpArrow) && count > 8){
			if(keyPosition !=1){
				keyPosition--;
			}else{
				keyPosition = 3;
			}
			SelectCursor(keyPosition);
			selectSceneName = ex.ToString();
		}
		else if(Input.GetKey(KeyCode.DownArrow) && count > 8){
			if(keyPosition !=3){
				keyPosition++;
			}else{
				keyPosition = 1;
			}
			SelectCursor(keyPosition);
			selectSceneName = ex.ToString();
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
		ex = (MenuButton) keyPosition;
		selectButtonName = "MainMenuButton_" + m_select.ToString();
		selectButton = GameObject.Find(selectButtonName);
		m_cursor.transform.localPosition = new Vector2(0,selectButton.transform.localPosition.y);
	}
}
