using UnityEngine;
using System.Collections;

public class GridDirector : MonoSingleton<GridDirector>
{
	public bool isDebugMode;
	
	void Start()
	{
	}
	
	void OnGUI()
	{/*
		if(GUILayout.Button ("Generate Small Test Level"))
		{
			GridGenerator.instance.Generate(Vector3.zero, 5, 5);
		}
		if(GUILayout.Button ("Generate Test Level from Texture"))
		{
			GridGenerator.instance.GenerateCurrentLevel(Vector3.zero);
		}*/
	}
}