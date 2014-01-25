using UnityEngine;
using System.Collections;

public class WithMouseActions : MonoBehaviour {

	bool mouseHovers = false;

	public bool MouseHovers() {
		return mouseHovers;
	}

	public RoomManager roomManager;

	void Start() {
		roomManager = GameObject.Find ("RoomManager").GetComponent<RoomManager> ();
		roomManager.RegisterWithMouseActions (this);
	}

	public void ResetHoverState() {
		mouseHovers = false;
	}

	public virtual void PerformOnClickAction() {
	}
	public virtual void PerformOnHoverAction() {
		mouseHovers = true;
	}
}
