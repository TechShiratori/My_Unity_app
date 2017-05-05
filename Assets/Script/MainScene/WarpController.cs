using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpController : MonoBehaviour {

	[SerializeField] private string warpNumber;
	[SerializeField] private Fade m_fade;
	private string warpPointName;
	private string warpName;
	private Collider2D playerCollider;
	private GameObject warpPoint;
	private int count = 0;
			
	void OnTriggerStay2D (Collider2D col){
		count++;
		if (Input.GetKeyDown(KeyCode.Z) && col.tag == "UnityChan" && count > 1) {
			warpName = this.name;
			warpPointName = "warp_point_" + warpName.Substring (14) + "to" + warpName.Substring (11, 1);
			warpPoint = GameObject.Find(warpPointName);
			count = 0;
			WarpOther(col,warpPoint);
		}
	}

	private void WarpOther(Collider2D player,GameObject warpPoint) {
		m_fade.FadeIn (0.3f, () => {
			player.gameObject.transform.position = warpPoint.gameObject.transform.position;
			m_fade.FadeOut (0.3f);
		});
	}
}