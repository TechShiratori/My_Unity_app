using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillList : MonoBehaviour {

	[SerializeField] private Text m_skillNameText;
	[SerializeField] private Text m_skillDesc;
	[SerializeField] private Image m_skillTexture;

	// Use this for initialization
	public void setSkill(Skill skill){
		m_skillNameText.text = skill.skillName;
		m_skillDesc.text = skill.skillDesc;
	}
}
