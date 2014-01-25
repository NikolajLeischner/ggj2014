using UnityEngine;
using System.Collections;

public class TrayController : WithMouseActions {

	public Sprite whole;
	public Sprite broken;

	void Start() {
		GetComponent<SpriteRenderer> ().sprite = whole;
	}

	public override void PerformOnClickAction ()
	{
		base.PerformOnClickAction ();
		
		GetComponent<SpriteRenderer> ().sprite = broken;
		GameObject key = GameObject.Find ("key");
		key.transform.position = new Vector3 (2.9f, -2.73f, 0.0f);
	}
}
