using UnityEngine;
using System.Collections;

public class Character {
	public int characterIndex; // 1-indexed
	public string Name;
	public Sprite characterPortrait;
	public string SceneSuffix;

	public static Character CharacterForId(int id) {
		switch (id) {
		case 1: return new Cat();
		case 2: return new Girl();
		case 3: return new Napoleon();
		default: return null;
		}
	}
}

public class Cat:Character {
	public Cat() {
		characterIndex = 1;
		Name = "Cat";
		characterPortrait = Resources.Load<Sprite> ("Characters/cat");
		SceneSuffix = "_cat";
	}
}

public class Girl:Character {
	public Girl() {
		characterIndex = 2;
		Name = "Girl";
		characterPortrait = Resources.Load<Sprite> ("Characters/girl");
		SceneSuffix = "_girl";
	}
}

public class Napoleon:Character {
	public Napoleon() {
		characterIndex = 3;
		Name = "Napoleon";
		characterPortrait = Resources.Load<Sprite> ("Characters/napoleon");
		SceneSuffix = "_napoleon";
	}
}
