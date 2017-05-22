using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillMenuController : MonoBehaviour
{
    [SerializeField] GameObject m_playerMenuController;
	[SerializeField] SkillContent skillContent;
    private int count = 0;
	private int keyPosition;
	void Start(){
		
	}
    public void Open()
    {
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
			SelectCursor(keyPosition);
		}

        if (Input.GetKey(KeyCode.X) && count > 8)
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
