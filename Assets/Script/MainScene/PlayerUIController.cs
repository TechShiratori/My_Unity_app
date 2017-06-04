using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerUIController : MonoBehaviour {
//HP、感染率、スキル、バッドステータス表示などプレイヤーUIに関連する処理はこっち
	[SerializeField] private GameObject m_hPBar;
	[SerializeField] private GameObject m_infectionBar;
	[SerializeField] private GameObject m_skillIconObj;
	[SerializeField] private GameObject m_weaponIcon;
	[SerializeField] private Text m_remaingBulletText;
	private GameObject m_skillIcons;
	private Image m_hpImage;
	private Image m_inImage;
	private List<Skill> m_playerSkills;
	private List<Weapon> m_playerWeapons;
	private ActSceneContoller m_actSceneController;
	private int m_selectWeapon = 0;
	void Start ()
	{
		m_hpImage = m_hPBar.GetComponent<Image> ();
		m_inImage = m_infectionBar.GetComponent<Image> ();
		m_skillIcons = GameObject.Find("GetSkill");
		m_actSceneController = transform.parent.gameObject.GetComponent<ActSceneContoller>();
	}

	public void ChangeRemaingBullet(){
		if(m_actSceneController.player.playerWeapons[m_selectWeapon].maxRemainingBullet != 0){
			m_remaingBulletText.text = m_actSceneController.player.playerWeapons[m_selectWeapon].remainingBullet.ToString();
		} else {
			m_remaingBulletText.text = "infinity";
		}
	}

	public void SetUI(){
		m_playerSkills = m_actSceneController.player.playerSkill;
		m_playerWeapons = m_actSceneController.player.playerWeapons;
		if(m_skillIcons.transform.childCount < m_playerSkills.Count){
			SetSkillIcon();
		}
		var weaponIconImage = m_weaponIcon.GetComponent<RawImage>();
		weaponIconImage.texture = Resources.Load<Texture2D>("Textures/" + m_playerWeapons[m_selectWeapon].weaponIconName);
		ChangeRemaingBullet();
	}

	public void SetWeaponIcon(Weapon playerWeapon){
		m_actSceneController.player.playerWeapons[m_selectWeapon] = playerWeapon;
		if(m_selectWeapon >= m_actSceneController.player.playerWeapons.Count - 1){
			m_selectWeapon = 0;
		}else{
			m_selectWeapon++;
		}
		m_actSceneController.player.equipWeapon = m_actSceneController.player.playerWeapons[m_selectWeapon];
	}

	public void SetSkillIcon(){
		foreach ( Transform n in m_skillIcons.transform )
		{
			GameObject.Destroy(n.gameObject);
		}
		for(int i = 0; i < m_playerSkills.Count; i++){
			//m_skillIconImage.texture = Resources.Load<Texture2D>("SkillIconSmall/" + m_playerSkills[i].skillIconName);
			var skillIconImage = m_skillIconObj.GetComponent<RawImage>();
			skillIconImage.texture = Resources.Load<Texture2D>("SkillIconSmall/" + m_playerSkills[i].skillIconName);
			Instantiate(m_skillIconObj,m_skillIcons.transform);
		}
	}

	public void ChangeLife (float effectPower){
		m_hpImage.fillAmount += effectPower/ 100f;
		if (m_hpImage.fillAmount >= 1) {
			m_hpImage.fillAmount = 1;
		}else if (m_hpImage.fillAmount <= 0) {
			m_actSceneController.State = "Restart";
		}
	}

	public void ChangeInfection (float effectPower){
		m_inImage.fillAmount += effectPower/ 100f;
		if (m_inImage.fillAmount >= 1) {
			m_actSceneController.State = "GameOver";
		}
	}
	public void ChangeStatus(int effectPower){
	}

	public void RestartRecover(){
		m_inImage.fillAmount += 0.1f;
		if (m_inImage.fillAmount >= 1) {
			m_actSceneController.State = "GameOver";
			return;
		}
		m_hpImage.fillAmount = 1;
	}
}
