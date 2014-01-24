using UnityEngine;
using System.Collections;

public class Dummy : Clickable {

	private RoomManager roomManager;

	void Start() {
		GameObject roomManagerInstance = GameObject.FindWithTag ("RoomManager");
		roomManager = roomManagerInstance.GetComponent<RoomManager> ();

	}

	protected override void PerformClickAction() {

		print ("Dummy was clicked");

		roomManager.MoveToNextRoom ();
	}
}
