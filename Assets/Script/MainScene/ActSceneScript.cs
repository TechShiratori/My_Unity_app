using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
/* アイテム取得、HP回復・減少の処理などの部分を格納するところ。各コントローラーから呼ばれる */
public class ActSceneScript : MonoBehaviour {

	[SerializeField] private ActSceneContoller m_actSceneController;
	[SerializeField] Image m_hpImage;
	[SerializeField] Image m_inImage;


	public void GetITem(List<string>itemListName, GameObject item){
		if(itemListName.Count<10){
			//itemList.Add(m_item);
			itemListName.Add(item.name);
			Debug.Log(itemListName.Count);
		}else{
			Debug.Log("所持アイテムがいっぱいです");
		}
	}

	public void ChangeLife (int effectPower){
		m_hpImage.fillAmount += effectPower/ 100f;
		if (m_hpImage.fillAmount >= 1) {
			m_hpImage.fillAmount = 1;
		}else if (m_hpImage.fillAmount <= 0) {
			m_actSceneController.State = "Restart";
		}
	}

	public void ChangeInfection (int effectPower){
		m_inImage.fillAmount += effectPower/ 100f;
		if (m_inImage.fillAmount >= 1) {
			m_actSceneController.State = "GameOver";
		}
	}
	public void ChangeStatus(int effectPower){
		/* 
		if(item.itemEffect_1 == Item.ItemEffect.ChangeLife){
			
		}
		*/
	}
	
	public void WarpOther(Fade fade,GameObject player,GameObject warpPoint) {
		
		string warpName = warpPoint.name;
		string warpPointName = "warp_point_" + warpName.Substring (14) + "to" + warpName.Substring (11, 1);
		warpPoint = GameObject.Find(warpPointName);
		fade.FadeIn (0.3f, () => {
			player.gameObject.transform.position = warpPoint.gameObject.transform.position;
			fade.FadeOut (0.3f);
		});
		StartCoroutine(m_actSceneController.WaitToAction(0.3f, () =>
    	{
        	m_actSceneController.toAction();
    	}));
	}
}
