using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponList : MonoBehaviour {

	[SerializeField] private Text m_weaponNameText;
	[SerializeField] private Text m_weaponDesc;
	[SerializeField] private RawImage m_weaponTexture;

	// Use this for initialization
	public void setWeapon(Weapon weapon){
		m_weaponNameText.text = weapon.weaponName;
		m_weaponDesc.text = weapon.weaponDesc;
		m_weaponTexture.texture = Resources.Load<Texture2D>("WeaponIcon/" + weapon.weaponIconName);
	}
}
