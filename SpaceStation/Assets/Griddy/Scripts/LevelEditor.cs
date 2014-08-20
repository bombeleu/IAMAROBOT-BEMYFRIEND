using UnityEngine;
using System.Collections;

public class LevelEditor : MonoSingleton<LevelEditor>
{
	//Changes in this document must be a reflection of those in "GridGenerator" which is the level loader
	//This is to ensure all tiles placed can be retrieved by the loader. all changes must be consistent.
	
	//Tiles used in Editor UI
	public GameObject gridSquare;
	
	
	//Variables used in editor
	public bool LevelDisplayed = false;
	public GameObject[] LoadedLevel;
	
	//Tiles used in game
	public GameObject floor;
	public GameObject wall;
	public GameObject LevelEnterDoor;
	public GameObject LevelExitDoor;
	
	//Tile color codes
	public Color WallGrey = Color.grey;
	public Color EnterDoorGreen = Color.green;
	public Color ExitDoorRed = Color.red;
	public Color FloorWhite = Color.white;
	public enum e_CameraMode{Play,Edit};
	public e_CameraMode e_Camera;
	
	//Pointers
	public GameObject GridCam;
	public void Start()
	{
		GridCam = Camera.mainCamera.gameObject;
	}
	//Unused
	//public GameObject hex;
	
	public Texture2D currentLevel;
	
	public void OnGUI()
	{
	switch(e_Camera)
		{
			case e_CameraMode.Play:
			{
			
				break;
			}
			case e_CameraMode.Edit:
			{
			
				break;
			}
			break;
		}
	}
	
	public void CreateNewMap(int width,int height)
	{
		if(LevelDisplayed == true)
		{
			//Display an error message about needing to delete the current map
		}
		if(LevelDisplayed == false)
		{
		currentLevel = new Texture2D(width,height);
			for(int i=0;i<currentLevel.width;i++)
			{
				for(int j=0;j<currentLevel.height;j++)
				{
					Color currentpixel = currentLevel.GetPixel(i,j);
					currentpixel = Color.clear;
				}
			}
		GenerateEditorGrid(Vector3.zero, width, height);
		GenerateCurrentLevel(Vector3.zero);
		LoadedLevel = GameObject.FindGameObjectsWithTag ("Tiles"); 
		LevelDisplayed = true;
		}
	}
	public void DeleteCurrentLevel()
	{
		for(int i=0;i<LoadedLevel.Length;i++)
		{
			Destroy(LoadedLevel[i]);
		}
		LevelDisplayed = false;
	}
	
	public void GenerateCurrentLevel (Vector3 origin)
	{
		for (int x = 0; x < currentLevel.width; x++)
		{
			for(int y = 0; y< currentLevel.height; y++)
			{
				Vector3 position = origin + new Vector3(x,0,y);
				Color currentTile = currentLevel.GetPixel(x,y);
				//Debug.Log(currentTile);
				
				//LEVEL ENTRY DOOR
				if(currentTile == EnterDoorGreen)
				{
					Vector3 entryDoorOffset = origin + new Vector3(x + 0.497f,0.547f,y);
					Instantiate(LevelEnterDoor, entryDoorOffset, Quaternion.identity);
										
				}
				
				else if(currentTile == ExitDoorRed)
				{
					Vector3 exitDoorOffset = origin + new Vector3(x,0.526f,y - 0.497f);
					Instantiate(LevelExitDoor,exitDoorOffset, Quaternion.identity);
					
				}
				
				//FloorTile
				else if(currentTile == FloorWhite)
				{
					Instantiate(floor,position,Quaternion.identity);
					
				}
				
				//WallTile
				else if(currentTile == WallGrey)
				{
					Vector3 wallOffset = origin + new Vector3(x,0.547f,y);
					Instantiate(wall,wallOffset,Quaternion.identity);
					
				}
				else if(currentTile == Color.clear)
				{
					//Empty space
				}
				
			}
		}
	}
	
	// Use this for initialization
	public void GenerateEditorGrid(Vector3 origin, int width, int height)
	{
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				Vector3 position = origin + new Vector3(x,0,y);
				Instantiate(gridSquare, position, Quaternion.identity);
				
						
			}
		}
	}
	
	
/*	public void GenerateHex(Vector3 origin, int width, int height)
	{
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				Vector3 position = origin + new Vector3(x * 1.75f,0,y * 1.5f);
				
				if(y % 2 == 0)
				{
					position += new Vector3((1.75f/2f),0,0);
				}
				
				Instantiate(hex, position, Quaternion.identity);
			}
		}
	}*/
}
