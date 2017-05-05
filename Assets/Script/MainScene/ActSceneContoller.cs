using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActSceneContoller : MonoBehaviour {
    public int numberOfWin = 0;
    public int numberOfLose = 0;
	public GameObject test; 
	public List<GameObject> itemList  = new List<GameObject>();
	public List<string> itemListName  = new List<string>();
	[SerializeField] private GameObject PlayerMenu;
	[SerializeField] private LifeController m_lifeScript;
	[SerializeField] private EnemyController m_enemyScript;
	[SerializeField] private PlayerController m_playerScript;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void FixedUpdate () {
		
	}

	public void OpenMenu(){

	}

	public void GetITem(GameObject m_item){
		if(itemList.Count<3){
			itemList.Add(m_item);
			Destroy(m_item);
			Debug.Log(itemList.Count);
		}else{
			Debug.Log("所持アイテムがいっぱいです");
		}
	}
}
