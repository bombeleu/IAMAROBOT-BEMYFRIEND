using UnityEngine;
using System.Collections;

public class GridGenerator : MonoSingleton<GridGenerator>
{
	//Tiles used in game
	public GameObject square;
	public GameObject wall;
	public GameObject LevelEnterDoor;
	public GameObject LevelExitDoor;
	
	//Tile color codes
	public Color WallGrey = Color.grey;
	public Color EnterDoorGreen = Color.green;
	public Color ExitDoorRed = Color.red;
	public Color FloorWhite = Color.white;
	
	
	
	//Unused
	public GameObject hex;
	
	
	public Texture2D currentLevel;
	
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
					Instantiate(square,position,Quaternion.identity);
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
	public void Generate(Vector3 origin, int width, int height)
	{
		for(int x = 0; x < width; x++)
		{
			for(int y = 0; y < height; y++)
			{
				Vector3 position = origin + new Vector3(x,0,y);
				Instantiate(square, position, Quaternion.identity);
				if(x == width-1) //rightWalls
				{
					Vector3 positionRightofTile = origin + new Vector3(x+1,0.547f,y);
					Instantiate(wall, positionRightofTile, Quaternion.identity);
				}
				if(y == height-1) //leftWalls
				{
					Vector3 positionLeftofTile = origin + new Vector3(x,0.547f,y+1);
					Instantiate(wall, positionLeftofTile, Quaternion.identity);
				}
				if(x == width-1 && y == height-1)
				{
					Vector3 positionCorner = origin + new Vector3(x+1,0.547f,y+1);
					Instantiate(wall,positionCorner,Quaternion.identity);
				}
				
			}
		}
	}
	
	// Use this for initialization
	public void GenerateHex(Vector3 origin, int width, int height)
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
	}
}
