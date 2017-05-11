using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

	public enum itemType{
		RecoverItem = 1,
		EventItem,
		EndingItem,
		PowerUpItem,
		SupportItem,
		ExpItem,
		OtherItem,
		Weapon
	}
	public itemType m_itemType;
	public bool importantFlag;
	public int healPoint;
	public string m_itemExplain;
	private UIController lifeScript;
	public int Point;
}
