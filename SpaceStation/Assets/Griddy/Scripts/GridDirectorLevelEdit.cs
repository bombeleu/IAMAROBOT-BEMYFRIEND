using UnityEngine;
using System.Collections;

public class GridDirectorLevelEdit : MonoSingleton<GridDirectorLevelEdit>
{
	public bool isDebugMode;
	public Vector3 CenterCamera;
	
	void Start()
	{
		CenterCamera.Set(-12.3f,9.5f,-12.9f);
	}
	
	void OnGUI()
	{
		if(GUILayout.Button ("Center Camera"))
		{
			Camera.mainCamera.transform.position = CenterCamera;
		}
		if(GUILayout.Button ("Create New Level - 8x8"))
		{
			LevelEditor.instance.CreateNewMap( 8, 8);
		}
		if(GUILayout.Button ("Create New Level - 10x10"))
		{
			LevelEditor.instance.CreateNewMap( 10, 10);
		}
		if(GUILayout.Button ("Create New Level - 16x16"))
		{
			LevelEditor.instance.CreateNewMap( 16, 16);
		}
		if(GUILayout.Button ("Create New Level - 32x32"))
		{
			LevelEditor.instance.CreateNewMap( 32, 32);
		}
		if(GUILayout.Button ("Delete Current Map"))
		{
			LevelEditor.instance.DeleteCurrentLevel();
		}
		
		/*if(GUILayout.Button ("Generate Test Level from Texture"))
		{
			LevelEditor.instance.GenerateCurrentLevel(Vector3.zero);
		}*/
	}
}