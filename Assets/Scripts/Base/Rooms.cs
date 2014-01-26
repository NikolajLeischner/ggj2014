using UnityEngine;
using System.Collections;

public class Rooms  {

	public static string PaddedCell = "PaddedCell";

	public static string Bedroom = "Bedroom";

	public static string Hallway = "Hallway";

	public static string Lobby = "Lobby";

	public static string Outro = "Outro";

	public static string SceneForCharacter(string scene, Character character) {
		if (scene == Rooms.Bedroom) return scene; 
else if (scene == Rooms.Outro) return scene;
		else
		return scene + character.SceneSuffix;
	}
}
