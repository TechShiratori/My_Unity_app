using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectStart : MonoBehaviour {

	private int keyPosition;
	private int count;
	private GameObject selectButton;
	private GameObject m_cursor;
	private string selectSceneName;
	private string selectButtonName;
	private TitleButton m_titleButton;
	private enum TitleButton{
		Main = 0,
		NewGame,
		LoadGame,
		Exit
	}
	void Start () {
		keyPosition = 1;
		m_cursor = GameObject.Find("Cursor");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow) && count > 8){
			if(keyPosition !=1){
				keyPosition--;
			}else{
				keyPosition = 3;
			}
			SelectCursor(keyPosition);
			selectSceneName = m_titleButton.ToString();
			Debug.Log("keyposition:" + keyPosition);
		}
		else if(Input.GetKey(KeyCode.DownArrow) && count > 8){
			if(keyPosition !=3){
				keyPosition++;
			}else{
				keyPosition = 1;
			}
			SelectCursor(keyPosition);
			selectSceneName = m_titleButton.ToString();
			Debug.Log("keyposition:" + keyPosition);
		}
		else if(Input.GetKey(KeyCode.Z) && count > 8 && keyPosition == 1){
			SceneManager.LoadScene("Floor1");
		}
		else if(Input.GetKey(KeyCode.Z) && count > 8 && keyPosition == 2){
			SceneManager.LoadScene("Floor1");
		}
		else if(Input.GetKey(KeyCode.Z) && count > 8 && keyPosition == 3){
			Application.Quit();
		}
		count++;
	}

	private void SelectCursor(int m_select){
		count = 0;
		m_titleButton = (TitleButton) keyPosition;
		selectButtonName = m_titleButton.ToString();
		selectButton = GameObject.Find(selectButtonName);
		Debug.Log("selectButtonName:" + selectButtonName);
		Debug.Log("selectButton:" + selectButton);
		m_cursor.transform.localPosition = new Vector2(0,selectButton.transform.localPosition.y);
	}
}
