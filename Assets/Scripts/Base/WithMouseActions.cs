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
		print ("I was clicked..");
	}
	public virtual void PerformOnHoverAction() {
		print ("hovering..");
		mouseHovers = true;
	}
}
