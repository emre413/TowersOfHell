using UnityEngine;
using System.Collections;

public enum GameState {
	CONT,
	WON,
	LOST
}

public class GameManager : MonoBehaviour {
	public int health;
	public GameState state;

	void Start () {
		health = 100;
		state = GameState.CONT;
	}

	void OnGUI() {
		GUIStyle gStyle = new GUIStyle ();

		gStyle.fontSize = 30;
		gStyle.normal.textColor = Color.blue;

		GUILayout.Label ("Health: " + health, gStyle);

		if (state == GameState.WON) {
			GUILayout.BeginArea (new Rect (0, Screen.height / 2.0f, Screen.width, Screen.height));
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Label (" You Won!", gStyle);
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();

			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();

			if (GUILayout.Button ("Restart")) {
				Application.LoadLevel (Application.loadedLevel);
			}

			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();
		} else if (state == GameState.LOST) {
			GUILayout.BeginArea (new Rect(0, Screen.height / 2.0f, Screen.width, Screen.height));
			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			GUILayout.Label(" You Lost!", gStyle);
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();

			GUILayout.BeginHorizontal ();
			GUILayout.FlexibleSpace ();
			if(GUILayout.Button("Try Again") ){
				Application.LoadLevel(Application.loadedLevel);
			}
			GUILayout.FlexibleSpace ();
			GUILayout.EndHorizontal ();
			GUILayout.EndArea ();
		}
	}

	void Update () {
	
	}
}
