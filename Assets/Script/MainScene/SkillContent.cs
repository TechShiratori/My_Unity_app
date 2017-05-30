using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillContent : MonoBehaviour
{

    private GameDataBase gameDataBase;
    // Use this for initialization
    void Start()
    {
        gameDataBase = GameObject.Find("GameDataBase").transform.GetComponent<GameDataBase>();
        SetSkillList();
    }

    public void SetSkillList()
    {
        int i = 0;
        GameObject objInstant;
        while (i < gameDataBase.skillDatabase.skills.Count)
        {

            GameObject skillListObj = (GameObject)Resources.Load("Prefab/SkillList");
            var skillListComponent = skillListObj.GetComponent<SkillList>();
            skillListComponent.setSkill(gameDataBase.skillDatabase.skills[i]);
            Vector2 pos = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
            objInstant = (GameObject)Instantiate(skillListObj, transform.position, Quaternion.identity);
            objInstant.transform.parent = transform;
            i++;
        }
    }

/* 
    public void SetSkillListVer2(int keyPosition){
        if (keyPosition + 1 > gameDataBase.skillDatabase.skills.Count){
            gameDataBase.skillDatabase.skills[keyPosition + 1] = null;
            gameDataBase.skillDatabase.skills[keyPosition] = null;
            gameDataBase.skillDatabase.skills[keyPosition - 1] = null;
        }

    }

    public void SetCenterItem(int index)
    {
        RectTransform scrollViewTfm = transform.parent as RectTransform;
        float height = scrollViewTfm.sizeDelta.y;
        float contentHeight = (transform as RectTransform).sizeDelta.y;
        if (contentHeight <= height)  // コンテンツよりスクロールエリアのほうが広いので、スクロールしなくてもすべて表示されている
            return;

        int n = transform.childCount;
        float y = (index + 0.5f) / n;  // 要素の中心座標
        float scrollY = y - 0.5f * height / contentHeight;
        float ny = scrollY / (1 - height / contentHeight);  // ScrollRect用に正規化した座標

        ScrollRect scrollRect = scrollViewTfm.GetComponent<ScrollRect>();
        scrollRect.verticalNormalizedPosition = Mathf.Clamp(1 - ny, 0, 1);  // Y軸は下から上なので反転してやる
    }
    */
}
