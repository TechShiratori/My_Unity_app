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

        m_sceneController.WarpFadeIn(0.3f, ()=>{
            player.gameObject.transform.position = warpPoint.gameObject.transform.position;
            m_actSceneController.toWait();
            m_sceneController.WarpFadeOut(0.3f, ()=>{
                StartCoroutine(m_actSceneController.WaitToAction(0.1f, () =>
                {
                    m_actSceneController.toAction();
                }));
            });
        });
    }

    public void NextArea(GameObject player,Action call = null){
        m_sceneController.WarpFadeIn(0.3f, ()=>{
            SceneManager.LoadScene("Floor2");
            StartCoroutine(m_actSceneController.WaitToAction(0.01f, () =>
                {
                    m_sceneController.SetBlackOut();
                    var startPoint = GameObject.FindWithTag("ReStartPoint");
                    Debug.Log(startPoint.transform.position);
                    player.gameObject.transform.position = startPoint.transform.position;
                }));
            /* 
            m_sceneController.SetAction(()=>{
                player.gameObject.transform.position = new Vector2(0,0);
            });
             
            m_actSceneController.toWait();
            m_sceneController.WarpFadeOut(0.3f, ()=>{
                StartCoroutine(m_actSceneController.WaitToAction(0.1f, () =>
                {
                    m_actSceneController.toAction();
                }));
            });
            */
        });
    }

    public void Restart(GameObject player)
    {
		var restartPoint = GameObject.FindWithTag("ReStartPoint");
        m_sceneController.WarpFadeIn(0.3f, ()=>{
            player.gameObject.transform.position = restartPoint.gameObject.transform.position;
            m_sceneController.WarpFadeOut(0.3f, () =>
            {
                m_actSceneController.toRestart();
            });
        });

        
    }
    public void GameOver(Action callback = null)
    {
        m_sceneController.OnFadeIn(0.3f);
        SceneManager.LoadScene("GameOver");
        callback();
    }
}
