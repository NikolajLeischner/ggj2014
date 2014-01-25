using UnityEngine;
using System.Collections;

public class GuardController : MonoBehaviour {

	bool isDistracted = false;

	public Sprite GuardWatching;
	public Sprite GuardDistracted;

	public bool IsDistracted(){
		return isDistracted;
		} 

	void Start () {
		GetComponent<SpriteRenderer> ().sprite = GuardWatching;
	}

	public void Distract() {
		GetComponent<SpriteRenderer> ().sprite = GuardDistracted;
		isDistracted = true;
	}
}
