using UnityEngine;
using System.Collections;

public class GuardController : MonoBehaviour {

	bool isDistracted = false;

	public Sprite GuardWatching;
	public Sprite GuardDistracted;
	public Sprite GuardDestroyed;

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

	public void Destroy() {
		GetComponent<SpriteRenderer> ().sprite = GuardDestroyed;
		isDistracted = true;
		}
}
