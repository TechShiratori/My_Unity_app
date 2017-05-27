using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour 
{
	public static LoadScene Instance{
		get; private set;
	}
	public int score = 0;

	void Awake()
	{
		if (Instance != null) {
			Destroy(gameObject);
			return;
		}
		Instance = this;
		DontDestroyOnLoad (gameObject);

		score = 30;
	}

	// click callback
	public void OnClick()
	{
		SceneManager.LoadScene("Floor2");
	}
}