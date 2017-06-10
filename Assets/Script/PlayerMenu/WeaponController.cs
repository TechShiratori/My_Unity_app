using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour {

    [SerializeField] GameObject m_playerMenuController;
	[SerializeField] RectTransform m_weaponRect;
	[SerializeField] Text WeaponName;
	[SerializeField] Text WeaponExplain;
	private GameDataBase m_gameDataBase;
    private int count = 0;
	private int m_index;
	void Start(){
		m_index = 1;
		//Open(Updateで連続呼び出し中)より順番が遅いためエラーが出る場合がある。処理自体は行われる模様
		m_gameDataBase = GameObject.Find("GameDataBase").GetComponent<GameDataBase>(); 
	}
	
    public void Open()
    {
		if(m_gameDataBase != null) ExplainSelectWeapon();

		if(Input.GetKey(KeyCode.RightArrow) && count > 8){
			count = 0;
			m_index++;
			if(m_index > m_gameDataBase.weaponDataBase.weapons.Count){
				m_index = 1;
			}
			Vector2 pos = m_weaponRect.transform.localPosition;
			Debug.Log(pos.y);
			pos.x -= 100;
			m_weaponRect.transform.localPosition = pos;
			SelectCursor();
			Debug.Log(m_index);
		}
		else if(Input.GetKey(KeyCode.LeftArrow) && count > 8){
			count = 0;
			m_index--;
			if(m_index < 1){
				m_index = m_gameDataBase.weaponDataBase.weapons.Count;
			}
			Vector2 pos = m_weaponRect.transform.localPosition;
			pos.x += 100;
			m_weaponRect.transform.localPosition = pos;
			SelectCursor();
			Debug.Log(m_index);
		}
		else if (Input.GetKey(KeyCode.X))
        {

            count = 0;
            var playerMenu = m_playerMenuController.GetComponent<PlayerMenuController>();
            string mainMenu = "Main";
            playerMenu.SelectMenu(mainMenu);
        }
		count++;
    }

	private void ExplainSelectWeapon(){
		WeaponName.text = m_gameDataBase.weaponDataBase.weapons[m_index-1].weaponName;
		WeaponExplain.text = m_gameDataBase.weaponDataBase.weapons[m_index-1].weaponDesc;
	}

	private void SelectCursor(){
		count = 0;
		//m_itemIconGroup.SetCursor(m_select);
	}
}
