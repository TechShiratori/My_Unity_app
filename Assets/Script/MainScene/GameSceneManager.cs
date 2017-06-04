using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour {

	public static GameSceneManager Instance{
		get; private set;
	}
	private GameObject m_actSceneObj;


	void Start () {
		if (Instance != null) {
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad(gameObject);
		m_actSceneObj = Resources.Load("Prefab/ActScene") as GameObject;
		var inst = Instantiate(m_actSceneObj,this.transform);
		inst.name = m_actSceneObj.name;
	}
}
