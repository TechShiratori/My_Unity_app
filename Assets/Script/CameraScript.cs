using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraScript: MonoBehaviour {

	private GameObject unitychan;

	void Start()
	{
		this.unitychan = GameObject.FindWithTag ("UnityChan");

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 cameraPos = this.transform.position;
		cameraPos.x = this.unitychan.transform.position.x;
		this.transform.position = cameraPos;
	}
}
