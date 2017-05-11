using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/* アイテム取得、HP回復・減少の処理などの部分を格納するところ。各コントローラーから呼ばれる */
public class ActSceneScript : MonoBehaviour {

	[SerializeField] private ActSceneContoller m_actSceneController;


	public void GetITem(List<string>itemListName, GameObject m_item){
		if(itemListName.Count<10){
			//itemList.Add(m_item);
			itemListName.Add(m_item.name);
			Debug.Log(itemListName.Count);
		}else{
			Debug.Log("所持アイテムがいっぱいです");
		}
	}

	public void LifeDown (Image hpImage,float hp,GameObject player){
		hpImage.fillAmount -= hp / 500f;
		if (hpImage.fillAmount <= 0) {
			m_actSceneController.State = "Restart";
		}
	}

	public void LifeUp (Image hpImage,GameObject recoverITem)
	{
		float hp = 20;
		hpImage.fillAmount += hp / 500f;
		if (hpImage.fillAmount >= 1) {
			hpImage.fillAmount = 1;
		}
	}

	public void InfectionDown (Image inImage,float infection){
		inImage.fillAmount -= infection / 250f;
	}

	public void InfectionUp (Image inImage,float infection,GameObject player)
	{
		inImage.fillAmount += infection / 250f;
		if (inImage.fillAmount >= 1) {
			m_actSceneController.State = "GameOver";
		}
	}
	
	public void WarpOther(Fade m_fade,GameObject player,GameObject warpPoint) {
		
		string warpName = warpPoint.name;
		string warpPointName = "warp_point_" + warpName.Substring (14) + "to" + warpName.Substring (11, 1);
		warpPoint = GameObject.Find(warpPointName);
		m_fade.FadeIn (0.3f, () => {
			player.gameObject.transform.position = warpPoint.gameObject.transform.position;
			m_fade.FadeOut (0.3f);
		});
		StartCoroutine(m_actSceneController.WaitToAction(0.3f, () =>
    	{
        	m_actSceneController.toAction();
    	}));
	}

	
}
