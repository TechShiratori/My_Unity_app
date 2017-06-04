using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* プレイヤーが複数人いるとき用だから今回は使わなさそう？ */
public class PlayerDataBase : MonoBehaviour {
	public List<Player> player = new List<Player>();
	public void SetDataBase(
		string name,
		int id, 
		string desc, 
		int life, 
		int infection, 
		int power, 
		int speed, 
		Player.PlayerHealth health, 
		Player.PlayerStatus status, 
		List<Item> items)
    {
			player.Clear();
			//player.Add(new Player(name,id,desc,life,infection,power,speed,health,status,items));
    }

	public void SetInitialize()	//初期のプレイヤーデータ
    {
			player.Clear();
			player.Add(new Player("リゼ",0,"裏切りの科学者",100,100,0,0,10,10,Player.PlayerHealth.Fine,Player.PlayerStatus.None,"",null,null,null,null,0));
    }
}
