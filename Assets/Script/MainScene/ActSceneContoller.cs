using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
/* あくまでこいつはステート（現在状況）の管理と分配なのでアイテムをゲットした時の処理は ActSceneScript に書くこと */
public class ActSceneContoller : MonoBehaviour {
    public int numberOfWin = 0;
    public int numberOfLose = 0;
	public int AllPoint = 0;
	public string State = "Start";
	public GameObject test; 
	public List<GameObject> itemList = new List<GameObject>();
	public List<string> itemListName  = new List<string>();
	public List<Item> backPack;
	[SerializeField] private PlayerMenuController m_playerMenuController;
	[SerializeField] private PlayerUIController m_playerUIController;
	[SerializeField] private PlayerController m_playerController;
	[SerializeField] private EnemyController m_enemyController;
	[SerializeField] private SceneController m_sceneController;
	[SerializeField] private WarpController m_warpController;
	[SerializeField] private UIController m_uiController;
	[SerializeField] private ActSceneScript m_actSceneScript;
	[SerializeField] private Fade m_fade;
	[SerializeField] private GameObject m_player;
	[SerializeField] private GameObject m_startPoint;
	public ItemDataBase database;
	private Item getItem;
	public enum ActionState {
		First = 1,
		Action,
		Event,
		Menu,
		Warp,
		Other
	}

	//[SerializeField] private MainMenuController m_mainMenu;

	public ActionState m_State; 
	// Use this for initialization
	void Start () {
		//m_sceneController.FirstFade();
		//StartCoroutine("WaitTime");
		//m_sceneController.OnFadeOut(0.5f);
		State = "Action";
		float dx = Time.deltaTime * 1f;
	}
	
	// Update is called once per frame
	void Update () {

		switch(State){
			case "First":  //プレイヤーフロア入場時演出などでアクション前に行う処理。特になければそのままActionで
				FirstAction();
				break;
			case "Action":	//通常アクションプレイ時。プレイヤー、エネミー、ギミックがアクション
				m_playerController.PlayerAction(); // プレイヤーアクション
				//m_playerMenuController.CloseMenu();
				Time.timeScale = 1;
				if (Input.GetKeyDown ("q")){
					State = "Menu";
					m_playerMenuController.FirstOpen();
				}
				break;
			case "Event":	//イベント中
				break;
			case "Menu":
				Time.timeScale = 0;
				m_playerMenuController.ActiveMenu();
				break;
			case "NextFloor": //フロア移動用。場所はwarpControllerに飛ばして、そこで処理？
					//m_sceneController.OnFadeIn(0.3f);
					StartCoroutine("WaitTime");
					SceneManager.LoadScene("Floor2");
				break;
			case "Warp": 
			//ワープ処理中。この間、敵味方も動かず不具合が起きないようにする。フェードが終わったあたりでFirstに移行？
			//とりあえず現状は何も書かない
				break;
			case "GameOver": //ゲームオーバー用
					//m_sceneController.OnFadeIn(0.3f);
					StartCoroutine("WaitTime");
					SceneManager.LoadScene("GameOver");
				break;
			case "Restart":
					m_playerUIController.Restart(m_player);
				break;
			default:
				break;
			}

	}
	void FixedUpdate () {
		
	}
	private void FirstAction () {
		//イベントフラグのif判定してあればEventControllerあたりで処理？その後Actionへ
		State = "Action";
	}
	public void Warp (GameObject player,GameObject warpPoint) {
		if(State == "Action"){
			State = ActionState.Warp.ToString();
			m_actSceneScript.WarpOther(m_fade,player,warpPoint);
		}
	}

	public void toAction(){
		State = ActionState.Action.ToString();
	}

	public void OpenMenu(){

	}

	public void GetITem(GameObject m_item){
		var itemName = m_item.name.Replace("(Clone)","");

		while(backPack.Count < 10){
			backPack.Add(database.items[0]);
		}

		for(int n =0 ; n < database.items.Count; n++){
			if(database.items[n].itemName == itemName){
				getItem = database.items[n];
			}
		}
		GetItemLoop(getItem);
	}

	private void GetItemLoop(Item m_getItem){

		for(int i = 0 ; i < 10; i++){
			if(backPack[i].itemName == null){
				backPack[i] = m_getItem;
				Debug.Log(backPack.Count);
				return;
			}
		}
		Debug.Log("所持アイテムがいっぱいです");
	}
	public IEnumerator WaitToAction(float waitTime,Action action){
        yield return new WaitForSeconds(waitTime);
		action();
    }
}
