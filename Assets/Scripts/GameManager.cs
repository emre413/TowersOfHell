using UnityEngine;
using System.Collections;

public enum GameState {
	CONT,
	WON,
	LOST
}

public enum PlayerType {
	Swordsman,
	Archer
}

public class GameManager : MonoBehaviour {
	public int health;
	public float playerHealth = 100f;
	public int gold = 500;
	public GameState state;
	public PlayerType playerType;


	void Start () {
		health = 20;
		state = GameState.CONT;
		playerType = PlayerType.Archer;
		Time.timeScale = 1;
	}

	void OnGUI() {
		
		GUIStyle gStyle = new GUIStyle ();
		gStyle.fontSize = 20;
		gStyle.normal.textColor = Color.blue;
		GUILayout.Label ("Castle Health: " + health, gStyle);

		GUIStyle gStyle_2 = new GUIStyle ();
		gStyle_2.fontSize = 20;
		gStyle_2.normal.textColor = Color.red;
		GUILayout.Label ("Player Health: " +  (int) playerHealth, gStyle_2);		

		GUIStyle gStyle_3 = new GUIStyle ();
		gStyle_3.fontSize = 20;
		gStyle_3.normal.textColor = Color.yellow;
		GUILayout.Label ("Gold: " +  gold , gStyle_3);

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
