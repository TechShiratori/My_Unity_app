using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuController : MonoBehaviour {

	private int keyPosition;
	private int count;
	private string selectButtonName;
	private string selectSceneName;
	private GameObject selectButton;
	private GameObject selectMenu;
	
	[SerializeField] private GameObject MainMenu;

	private enum MenuButton{
		Main = 0,
		Item,
		Skill,
		Option
	}

	[SerializeField] private GameObject m_cursor;
	private MenuButton ex;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void SelectManu(int m_select){
		for(int i = 0; i < transform.childCount; i++){
			if(selectSceneName == transform.GetChild (i).gameObject.name){
				selectMenu = transform.GetChild (i).gameObject;
			}
		}
	}
}
