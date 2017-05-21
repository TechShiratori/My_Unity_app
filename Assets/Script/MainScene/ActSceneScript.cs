using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class ActSceneScript : MonoBehaviour {
//アイテムの取得、ワープなどUIに直接関連しない処理はこっち
	[SerializeField] private ActSceneContoller m_actSceneController;
	[SerializeField] private GameObject m_startPoint;
	[SerializeField] private Fade m_fade;
	public void GetITem(List<string>itemListName, GameObject item){
		if(itemListName.Count<10){
			itemListName.Add(item.name);
			Debug.Log(itemListName.Count);
		}else{
			Debug.Log("所持アイテムがいっぱいです");
		}
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
	public void Restart(GameObject player){
		m_fade.FadeIn (0.3f, () => {
			player.gameObject.transform.position = m_startPoint.gameObject.transform.position;
			m_fade.FadeOut (0.3f);
		});
	}
	public void GameOver(){
		m_fade.FadeIn (0.3f);
		SceneManager.LoadScene ("GameOver");
	}
}
