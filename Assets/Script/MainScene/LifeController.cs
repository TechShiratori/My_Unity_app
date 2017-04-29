using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {

	[SerializeField] private GameObject m_hPBar;
	[SerializeField] private GameObject m_infectionBar;
	RectTransform hprt;
	RectTransform inrt;

	void Start ()
	{
		hprt = m_hPBar.GetComponent<RectTransform>();
		inrt = m_infectionBar.GetComponent<RectTransform>();
		//rt = GetComponent<RectTransform>();
	}

	public void LifeDown (int ap){
		//RectTransformのサイズを取得し、マイナスする
		hprt.sizeDelta -= new Vector2 (0,ap);
	}

	public void LifeUp (int hp)
	{
		//RectTransformのサイズを取得し、プラスする
		hprt.sizeDelta += new Vector2 (0,hp);
		//最大値を超えたら、最大値で上書きする
		if (hprt.sizeDelta.y > 240f) {
			hprt.sizeDelta = new Vector2 (51f, 240f);
		}
	}

	public void InfectionDown (int infection){
		//RectTransformのサイズを取得し、マイナスする
		hprt.sizeDelta -= new Vector2 (0,infection);
		//最小値を超えたら、最小値で上書きする
		if (inrt.sizeDelta.x < 0) {
			inrt.sizeDelta = new Vector2 (0, 0);
		}
	}

	public void InfectionUp (int infection)
	{
		//RectTransformのサイズを取得し、プラスする
		inrt.sizeDelta += new Vector2 (infection,0);
		//最大値を超えたら、最大値で上書きする
		if (hprt.sizeDelta.x > 500f) {
			hprt.sizeDelta = new Vector2 (500f, 20f);
		}
	}
}