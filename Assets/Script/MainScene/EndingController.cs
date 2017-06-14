using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndingController : MonoBehaviour {

	void Update(){
		if (Input.GetKeyDown ("z")){
			SceneManager.LoadScene("TitleScene");
		}
	}
}
