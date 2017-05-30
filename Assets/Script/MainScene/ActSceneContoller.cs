using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
/* あくまでこいつはステート（現在状況）の管理と分配なのでアイテムをゲットした時の処理は ActSceneScript に書くこと */
public class ActSceneContoller : MonoBehaviour {
	public string State = "Start";
	//public List<Item> backPack;
	public Player player;
	[SerializeField] private PlayerMenuController m_playerMenuController;
	[SerializeField] private PlayerUIController m_playerUIController;
	[SerializeField] private PlayerController m_playerController;
	[SerializeField] private ActSceneScript m_actSceneScript;
	[SerializeField] private Fade m_fade;
	[SerializeField] private GameObject m_player;
	[SerializeField] private GameDataBase dataBase;
	public enum ActionState {
		First = 1,
		Action,
		Wait,
		Event,
		Menu,
		Warp,
		Other
	}
	public enum ChangeState{
		Nothing = 1,
		Damage,
		Recover,
		PowerUP,
		PowerDown,
		BadStatus
	}
	void Start () {
		State = "First";
		float dx = Time.deltaTime * 1f; //いらない？
	}
	
	// Update is called once per frame
	void Update () {

		switch(State){
			case "First":  //プレイヤーの初期状態設定などプレイヤーフロア入場時演出などでアクション前に行う処理。
				FirstAction();
				break;
			case "Action":	//通常アクションプレイ時。プレイヤー、エネミー、ギミックがアクション
				m_playerController.PlayerAction(); // プレイヤーアクション
				Time.timeScale = 1;
				if (Input.GetKeyDown ("q")){
					State = "Menu";
					m_playerMenuController.FirstOpen();
				}
				break;
			case "Wait":	//プレイヤーだけが動けない状態
				break;
			case "Event":	//イベント中
				break;
			case "Menu":
				Time.timeScale = 0;
				m_playerMenuController.ActiveMenu();
				break;
			case "NextFloor": //フロア（シーン）移動用。
					StartCoroutine("WaitTime");
					SceneManager.LoadScene("Floor2");
				break;
			case "Warp": 
				break;
			case "GameOver":
					m_actSceneScript.GameOver();
				break;
			case "Restart":
					m_actSceneScript.Restart(m_fade,m_player);
				break;
			default:
				break;
			}
	}
	private void FirstAction () {
		//イベントフラグのif判定してあればEventControllerあたりで処理？その後Actionへ
		//プレイヤーの状態設定（セーブロードじゃなければ、初期設定のを読み込む）
		player = dataBase.currentPlayer;
		//Debug.Log(player.playerName);
		State = "Action";
	}
	public void toWarp (GameObject player,GameObject warpPoint) {
		if(State == "Action"){
			State = ActionState.Warp.ToString();
			m_actSceneScript.WarpOther(m_fade,player,warpPoint);
		}
	}
	public void toNextArea (GameObject player,GameObject warpPoint) {
		if(State == "Action"){
			State = ActionState.Warp.ToString();
			m_actSceneScript.NextArea(m_fade,player);
		}
	}

	public void toAction(){
		State = ActionState.Action.ToString();
	}
	public void toWait(){
		State = ActionState.Wait.ToString();
	}
	public void toRestart(){
		m_playerUIController.ChangeLife(100);
		StartCoroutine(WaitToAction(0.5f, () =>
        {
            toAction();
        }));
	}

	public void SavePlayer(){
		dataBase.Save(player);
	}
	public void LoadPlayer(){
		player = dataBase.Load();
	}

	public void GetSkill(Skill skill){
		player.playerSkill.Add(skill);
	}

	public void GetITem(GameObject item){
		var itemName = item.name.Replace("(Clone)","");


		while(player.playerItems.Count < 10){
			player.playerItems.Add(dataBase.itemDatabase.items[0]);
		}

		for(int n =0 ; n < dataBase.itemDatabase.items.Count; n++){
			if(dataBase.itemDatabase.items[n].itemName == itemName){
				GetItemLoop(dataBase.itemDatabase.items[n]);
				break;
			}
		}
		
	}

	private void GetItemLoop(Item getItem){

		for(int i = 0 ; i < 10; i++){
			if(player.playerItems.Count == 0){
				player.playerItems[i] = getItem;
				Debug.Log(player.playerItems.Count);
				return;
			}else if (player.playerItems[i].itemID == 0){
				player.playerItems[i] = getItem;
				Debug.Log(player.playerItems.Count);
				return;
			}
		}
		Debug.Log("所持アイテムがいっぱいです");
	}

	public void DamageEffect(int effectPower){
		m_playerUIController.ChangeLife(effectPower * -1);
		m_playerUIController.ChangeInfection(effectPower * 0.1f);
	}

	public void ActiveEffect(Effect effect){
		SelectEffect(effect.effectType_1,effect.effectPower_1);
		SelectEffect(effect.effectType_2,effect.effectPower_2);
	}

	public void SelectEffect(Effect.EffectType effectType,int effectPower){

		switch (effectType)
		{
        case Effect.EffectType.ChangeLife:
		
            m_playerUIController.ChangeLife(effectPower);
            break;
		
		case Effect.EffectType.ChangeInfection:
            m_playerUIController.ChangeInfection(effectPower);
            break;
		}
	}

	public IEnumerator WaitToAction(float waitTime,Action action){
        yield return new WaitForSeconds(waitTime);
		action();
    }


}
