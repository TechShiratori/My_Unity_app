using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenuController : MonoBehaviour {
[SerializeField] GameObject m_playerMenuController;
private int count = 0;
	public void Open(){
		if (Input.GetKey(KeyCode.X) && count > 8){
			count = 0;
			var playerMenu = m_playerMenuController.GetComponent<PlayerMenuController>();
			string mainMenu = "Main";
			playerMenu.SelectMenu(mainMenu);
		}
		count++;
	}
}
