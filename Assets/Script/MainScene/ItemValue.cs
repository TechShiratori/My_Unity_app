using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemValue : MonoBehaviour {

	public int healPoint;
	[SerializeField] private GameObject m_Item;

	private string description;



	void Start () {
		
	}
	

	public void SetItemEffect(GameObject ItemObj){
		switch(ItemObj.name){
			case "Bantage":
				description = "HP30%回復";
				break;
			case "Aidkit":
				description = "HP100%回復";
				break;
			case "general vaccine":
				description = "感染率30%減少";
				break;
			default:
				break;
			}
	}
}
