using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemIcon : MonoBehaviour {

	[SerializeField] private GameObject m_cursor;
	
	public void SetCursor(GameObject m_item){
		m_item.SetActive(true);
	}

}
