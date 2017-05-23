﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillMenuController : MonoBehaviour
{
    [SerializeField] GameObject m_playerMenuController;
	[SerializeField] SkillContent m_skillContent;
	[SerializeField] RectTransform m_skillRect;
	private GameDataBase m_gameDataBase;
    private int count = 0;
	private int m_index = 0;
	private int m_skillAllCount;
	void Start(){
		m_index = 3;
		m_gameDataBase = GameObject.Find("GameDataBase").transform.GetComponent<GameDataBase>();
		m_skillAllCount = m_gameDataBase.skillDatabase.skills.Count;
		Debug.Log(m_skillAllCount);
	}
    public void Open()
    {
		if(Input.GetKey(KeyCode.DownArrow) && count > 8){
			count = 0;
			m_index++;
			if(m_index >= m_skillAllCount){
				m_index = 0;
			}
			Vector2 pos = m_skillRect.transform.position;
			pos.y += 100;
			m_skillRect.transform.position = pos;
			SelectCursor(m_index);
			Debug.Log(m_index);
		}
		else if(Input.GetKey(KeyCode.UpArrow) && count > 8){
			count = 0;
			m_index--;
			if(m_index < 0){
				m_index = m_skillAllCount - 1;
			}
			Vector2 pos = m_skillRect.transform.position;
			pos.y -= 100;
			m_skillRect.transform.position = pos;
			SelectCursor(m_index);
			Debug.Log(m_index);
		}
		if (Input.GetKey(KeyCode.X) && count > 8)
        {
            count = 0;
            var playerMenu = m_playerMenuController.GetComponent<PlayerMenuController>();
            string mainMenu = "Main";
            playerMenu.SelectMenu(mainMenu);
        }
        if (Input.GetKey(KeyCode.Z) && count > 8)
        {
            count = 0;
			var checkSkill = m_gameDataBase.skillDatabase.skills[m_index];
            var check = m_gameDataBase.skillDatabase.mySkills.Find(x => x.skillID == checkSkill.skillID);
            Debug.Log(check);
            if (check == null)
            {
                Debug.Log(checkSkill.skillName);
                m_gameDataBase.getSkillData(checkSkill);
            }
			Debug.Log(m_gameDataBase.skillDatabase.mySkills.Count);
        }
        count++;	
    }

	private void SelectCursor(int m_select){
		count = 0;
		//m_itemIconGroup.SetCursor(m_select);
	}
}
