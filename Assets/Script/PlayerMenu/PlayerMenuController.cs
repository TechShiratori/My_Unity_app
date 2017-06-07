using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerMenuController : MonoBehaviour {
	[SerializeField] private GameObject m_actSceneController;
	[SerializeField] private GameObject m_mainMenu;
	[SerializeField] private GameObject m_weaponMenu;
	[SerializeField] private GameObject m_itemMenu;
	[SerializeField] private GameObject m_skillMenu;
	[SerializeField] private GameObject m_optionMenu;
	public enum MenuState{
		Main = 0,
		Weapon,
		Item,
		Skill,
		Option,
		NotActive
	}
	public MenuState menuState = MenuState.Main;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ActiveMenu(){
		if(menuState == MenuState.Main){
			openMainMenu();
		}else if(menuState == MenuState.Weapon){
			openWeaponMenu();
		}else if(menuState == MenuState.Item){
			openItemMenu();
		}else if(menuState == MenuState.Skill){
			openSkillMenu();
		}else if(menuState == MenuState.Option){
			openOptionMenu();
		}else if(menuState == MenuState.NotActive){
			CloseMenu();
		}
	}

	public void SelectMenu(string selectMenu){
		menuState = (MenuState)Enum.Parse(typeof(MenuState), selectMenu);
	}

	public void openMainMenu(){
		var m_mainMenuController = m_mainMenu.GetComponent<MainMenuController>();
		menuState = MenuState.Main;
		m_mainMenuController.Open();
		m_mainMenu.SetActive(true);
		m_weaponMenu.SetActive(false);
		m_itemMenu.SetActive(false);
		m_skillMenu.SetActive(false);
		m_optionMenu.SetActive(false);
	}
	public void openWeaponMenu(){
		var m_weaponController = m_weaponMenu.GetComponent<WeaponController>();
		m_mainMenu.SetActive(false);
		m_weaponMenu.SetActive(true);
		m_weaponController.Open();
	}
	public void openItemMenu(){
		var m_itemMenuController = m_itemMenu.GetComponent<ItemMenuController>();
		m_mainMenu.SetActive(false);
		m_itemMenu.SetActive(true);
		m_itemMenuController.Open();
	}
	public void openSkillMenu(){
		var m_skillMenuController = m_skillMenu.GetComponent<SkillMenuController>();
		m_mainMenu.SetActive(false);
		m_skillMenu.SetActive(true);
		m_skillMenuController.Open();
	}
	public void openOptionMenu(){
		var m_optionMenuController = m_optionMenu.GetComponent<OptionMenuController>();
		m_mainMenu.SetActive(false);
		m_optionMenu.SetActive(true);
		m_optionMenuController.Open();
	}

	public void FirstOpen () {
		menuState = MenuState.Main;
	}
	public void CloseMenu () {
		var actSceneController = m_actSceneController.GetComponent<ActSceneContoller>();
		m_mainMenu.SetActive(false);
		actSceneController.State = "Action";
	}
	public void BackMainMenu () {
		m_mainMenu.SetActive(true);
		m_itemMenu.SetActive(false);
		m_skillMenu.SetActive(false);
		m_optionMenu.SetActive(false);
	}
}
