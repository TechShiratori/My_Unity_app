using UnityEngine;
using System.Collections;

public class ExplosionController
	: MonoBehaviour {

	public void DeleteExplosion ()
	{
		Destroy(gameObject);
	}
}