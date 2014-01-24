using UnityEngine;
using System.Collections;



public class GameManager {

	private static GameManager singleton;

	public string currentRoom = "";

	public static string paddedCellScene = "PaddedCell";

	public static GameManager instance() {
		if (singleton == null) {
			singleton = new GameManager();		
		}
		return singleton;
	}

}
