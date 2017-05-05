using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour {

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

	public bool importantFlag;

	public int healPoint;
	private LifeController lifeScript;
	void Start ()
	{
	}

	void OnCollisionEnter2D (Collision2D col)
	{
	}
}
