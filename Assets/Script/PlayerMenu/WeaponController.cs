using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    [SerializeField] GameObject m_playerMenuController;
	[SerializeField] RectTransform m_weaponRect;
    private int count = 0;
	private int m_index = 0;
	private int m_skillAllCount;
	void Start(){
		m_index = 1;
		var gameSceneManager = transform.root.gameObject;
	}
	
    public void Open()
    {
		if (Input.GetKey(KeyCode.X))
        {
            count = 0;
            var playerMenu = m_playerMenuController.GetComponent<PlayerMenuController>();
            string mainMenu = "Main";
            playerMenu.SelectMenu(mainMenu);
        }
		count++;
    }

	private void SelectCursor(int m_select){
		count = 0;
		//m_itemIconGroup.SetCursor(m_select);
	}
}
