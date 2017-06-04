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
    private GameObject m_playerObj;

    public void SetInitialize(SceneController sceneController, GameObject playerObj){
        
        m_sceneController = sceneController;
        m_playerObj = playerObj;
        
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
    public void WarpOther(GameObject warpPoint)
    {

        string warpName = warpPoint.name;
        string warpPointName = "warp_point_" + warpName.Substring(14) + "to" + warpName.Substring(11, 1);
        warpPoint = GameObject.Find(warpPointName);

        m_sceneController.WarpFadeIn(0.3f, ()=>{
            m_playerObj.gameObject.transform.position = warpPoint.gameObject.transform.position;
            m_actSceneController.toWait();
            m_sceneController.WarpFadeOut(0.3f, ()=>{
                StartCoroutine(m_actSceneController.WaitToAction(0.1f, () =>
                {
                    m_actSceneController.toAction();
                }));
            });
        });
    }

    public void NextArea(Action call = null){
        m_sceneController.WarpFadeIn(0.3f, ()=>{
            SceneManager.LoadScene("Floor2");
            m_sceneController.SetBlackOut();
            StartCoroutine(m_actSceneController.WaitToAction(0.01f, () =>
                {
                    m_sceneController.SetBlackOut();
                    var startPoint = GameObject.FindWithTag("ReStartPoint");
                    Debug.Log(startPoint.transform.position);
                    m_playerObj.gameObject.transform.position = startPoint.transform.position;
                }));
        });
    }
    public void LoadPosition(Player player,Action call = null){
        m_sceneController.WarpFadeIn(0.3f, ()=>{
            SceneManager.LoadScene(player.playerSave);
            m_sceneController.SetBlackOut();
            StartCoroutine(m_actSceneController.WaitToAction(0.01f, () =>
                {
                    m_sceneController.FirstFadeOut();
                    var savePoint = GameObject.FindWithTag("SavePoint");
                    Debug.Log(savePoint.transform.position);
                    m_playerObj.gameObject.transform.position = savePoint.transform.position;
                }));
        });
    }

    public void Restart()
    {
		var restartPoint = GameObject.FindWithTag("ReStartPoint");
        m_sceneController.WarpFadeIn(0.3f, ()=>{
            m_playerObj.gameObject.transform.position = restartPoint.gameObject.transform.position;
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
