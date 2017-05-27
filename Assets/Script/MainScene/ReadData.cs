using UnityEngine;
using System.Collections;

public class ReadData : MonoBehaviour 
{
	void Start () 
	{
		LoadScene loadScene = LoadScene.Instance;
		Debug.Log (loadScene.score);
	}
}