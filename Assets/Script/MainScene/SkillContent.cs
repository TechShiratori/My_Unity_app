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

}
