using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;
public class ActSceneScript : MonoBehaviour
{
    //アイテムの取得、ワープなどUIに直接関連しない処理はこっち
    [SerializeField] private ActSceneContoller m_actSceneController;
    private SceneController m_sceneController;

    public void SetInitialize(SceneController sceneController){
        
        m_sceneController = sceneController;
    }
    public void GetITem(List<string> itemListName, GameObject item)
    {
        if (itemListName.Count < 10)
        {
            itemListName.Add(item.name);
            Debug.Log(itemListName.Count);
        }
        else
        {
            Debug.Log("所持アイテムがいっぱいです");
        }
    }
    public void WarpOther(GameObject player, GameObject warpPoint)
    {

        string warpName = warpPoint.name;
        string warpPointName = "warp_point_" + warpName.Substring(14) + "to" + warpName.Substring(11, 1);
        warpPoint = GameObject.Find(warpPointName);

        m_sceneController.WarpFadeInOut(0.3f, ()=>{
            player.gameObject.transform.position = warpPoint.gameObject.transform.position;
        });
        

		m_actSceneController.toWait();

        StartCoroutine(m_actSceneController.WaitToAction(0.5f, () =>
        {
            m_actSceneController.toAction();
        }));
    }

    public void NextArea(GameObject player){
        SceneManager.LoadScene("Floor2");
    }

    public void Restart(GameObject player)
    {
		var restartPoint = GameObject.FindWithTag("ReStartPoint");
        m_sceneController.WarpFadeInOut(0.3f, ()=>{
            player.gameObject.transform.position = restartPoint.gameObject.transform.position;
        });
        m_actSceneController.toRestart();
    }
    public void GameOver(Action callback = null)
    {
        m_sceneController.OnFadeIn(0.3f);
        SceneManager.LoadScene("GameOver");
        callback();
    }
}
