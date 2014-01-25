using UnityEngine;
using System.Collections;

public class TrashController : WithMouseActions {
	
	public Sprite whole;
	public Sprite broken;
	
	void Start() {
		GetComponent<SpriteRenderer> ().sprite = whole;
	}
	
	public override void PerformOnClickAction ()
	{
		base.PerformOnClickAction ();
		
		GetComponent<SpriteRenderer> ().sprite = broken;
		GameObject pin = GameObject.Find ("pin");
		pin.transform.position = new Vector3 (3.140685f, -2.268516f, 0.0f);
	}
}