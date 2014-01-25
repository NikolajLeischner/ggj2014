using UnityEngine;
using System.Collections;

public class Dummy : WithMouseActions {

	private RoomManager roomManager;

	void Start() {
		GameObject roomManagerInstance = GameObject.FindWithTag ("RoomManager");
		roomManager = roomManagerInstance.GetComponent<RoomManager> ();

	}

	public override void PerformOnClickAction() {

		print ("Dummy was clicked");

		roomManager.MoveToNextRoom ();
	}
}
