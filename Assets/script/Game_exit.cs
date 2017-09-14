using UnityEngine;
using System.Collections;

public class Game_exit : MonoBehaviour {

	public int windowWidth = 600;
	public int windowHight = 225;

	private Rect windowRect ;
	private int windowSwitch = 0;
	private float alpha = 0;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			windowSwitch = 1;
			alpha = 0; // Init Window Alpha Color
		}
	}

	void GUIAlphaColor_0_To_1 ()
	{
		if (alpha < 1) {
			alpha += Time.deltaTime;
			GUI.color = new Color (1, 1, 1, alpha);
		} 
	}


	void Awake ()
	{
		windowRect = new Rect (
			(Screen.width - windowWidth) / 2,
			(Screen.height - windowHight) / 2,
			windowWidth,
			windowHight);
	}

	void OnGUI ()
	{ 
		if (windowSwitch == 1) {
			GUIAlphaColor_0_To_1 ();
			windowRect = GUI.Window (0, windowRect, QuitWindow, "Quit Window");
		}
	}
	
	void QuitWindow (int windowID)
	{
		GUI.skin.button.fontSize = 20;
		GUI.skin.label.fontSize = 20;

		GUI.Label (new Rect (150, 75, 450, 45), "Are you sure you want to quit game ?");
		
		if (GUI.Button (new Rect (120, 165, 150, 30), "Quit")) {
			Application.Quit ();
		} 
		if (GUI.Button (new Rect (330, 165, 150, 30), "Cancel")) {
			windowSwitch = 0; 
		} 
		
		GUI.DragWindow (); 
	}
}
