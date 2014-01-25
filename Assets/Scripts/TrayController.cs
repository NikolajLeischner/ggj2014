using UnityEngine;
using System.Collections;

public class TrayController : Clickable {

	public Sprite whole;
	public Sprite broken;

	void Start() {
		GetComponent<SpriteRenderer> ().sprite = whole;
	}

	protected override void PerformClickAction ()
	{
		base.PerformClickAction ();
		
		GetComponent<SpriteRenderer> ().sprite = broken;
		GameObject key = GameObject.FindWithTag ("Key");
		key.transform.position = new Vector3 (2.9f, -2.73f, 0.0f);
	}
}
