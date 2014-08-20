using UnityEngine;
using System.Collections;

public class consoleKey : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(Application.loadedLevelName == "LevelEditor-DEV" || Application.loadedLevelName == "LevelEditor")
		{}
		else{DebugConsole.IsOpen = true;}
	}
	
	// Update is called once per frame
	void Update () {
	if(Input.GetKeyDown(KeyCode.Tab))
		{
			if(DebugConsole.IsOpen == false)
			{
				DebugConsole.IsOpen = true;
			}
			else if(DebugConsole.IsOpen == true)
			{
				DebugConsole.IsOpen = false;
			}
		}
	}
}
