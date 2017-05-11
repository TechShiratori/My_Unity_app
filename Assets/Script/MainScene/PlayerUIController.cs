using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUIController : MonoBehaviour {

	[SerializeField] private GameObject m_hPBar;
	[SerializeField] private GameObject m_infectionBar;
	[SerializeField] private GameObject m_startPoint;
	[SerializeField] private Fade m_fade;
	private Image hpImage;
	private Image inImage;
	void Start ()
	{
		hpImage = m_hPBar.GetComponent<Image> ();
		inImage = m_infectionBar.GetComponent<Image> ();
	}

	public void LifeDown (float hp,GameObject player){
		hpImage.fillAmount -= hp / 500f;
		if (hpImage.fillAmount <= 0) {
			Restart (player);
		}
	}

	public void LifeUp (GameObject recoverITem)
	{
		float hp = 20;
		hpImage.fillAmount += hp / 500f;
		if (hpImage.fillAmount >= 1) {
			hpImage.fillAmount = 1;
		}

	}

	public void InfectionDown (float infection){
		inImage.fillAmount -= infection / 250f;
	}

	public void InfectionUp (float infection,GameObject player)
	{
		inImage.fillAmount += infection / 250f;
		if (inImage.fillAmount >= 1) {
			GameOver();
		}
	}

	public void Restart(GameObject player){
		m_fade.FadeIn (0.3f, () => {
			player.gameObject.transform.position = m_startPoint.gameObject.transform.position;
			hpImage.fillAmount = 1;
			m_fade.FadeOut (0.3f);
		});
	}

	public void GameOver(){
		m_fade.FadeIn (0.3f);
		Application.LoadLevel ("GameOver");
	}
}
