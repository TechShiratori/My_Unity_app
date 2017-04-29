﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour {

	[SerializeField] private GameObject hPBar;
	RectTransform rt;

	void Start ()
	{
		rt = hPBar.GetComponent<RectTransform>();
		//rt = GetComponent<RectTransform>();
	}

	public void LifeDown (int ap){
		//RectTransformのサイズを取得し、マイナスする
		rt.sizeDelta -= new Vector2 (0,ap);
	}

	public void LifeUp (int hp)
	{
		//RectTransformのサイズを取得し、プラスする
		rt.sizeDelta += new Vector2 (0,hp);
		//最大値を超えたら、最大値で上書きする
		if (rt.sizeDelta.y > 240f) {
			rt.sizeDelta = new Vector2 (51f, 240f);
		}
	}
}