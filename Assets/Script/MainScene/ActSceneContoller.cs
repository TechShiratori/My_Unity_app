using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActSceneContoller : MonoBehaviour {
    public int numberOfWin = 0;
    public int numberOfLose = 0;
	public int AllPoint = 0;
	public GameObject test; 
	public List<GameObject> itemList;
	public List<string> itemListName  = new List<string>();
	[SerializeField] private GameObject PlayerMenu;
	[SerializeField] private LifeController m_lifeScript;
	[SerializeField] private EnemyController m_enemyScript;
	[SerializeField] private PlayerController m_playerScript;

	// Use this for initialization
	void Start () {
		 //itemList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
		
	}

	public void OpenMenu(){

	}

	public void GetITem(GameObject m_item){
		if(itemListName.Count<10){
			//itemList.Add(m_item);
			itemListName.Add(m_item.name);
			Debug.Log(itemList.Count);
		}else{
			Debug.Log("所持アイテムがいっぱいです");
		}
	}
}
