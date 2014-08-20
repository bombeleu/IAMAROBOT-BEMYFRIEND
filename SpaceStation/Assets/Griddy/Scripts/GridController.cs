using UnityEngine;
using System.Collections;

public class GridController : MonoBehaviour {
	
	public GridView view;
	
	
	

	public void OnGUI()
	{
		
	}
	
	public virtual void Trigger(TriggerEvent triggerEvent)
	{
		switch(triggerEvent)
		{
			case TriggerEvent.StartHover:
				//Debug.Log ("Hover Started");
				view.SetState(ViewState.Acceptable);
				
				break;
			
			case TriggerEvent.StopHover:
				//Debug.Log ("Hover Stopped");
				view.SetState(ViewState.Default);
				break;
			
			case TriggerEvent.LeftClick:
				//Debug.Log ("Left Click");
				Destroy(view.gameObject);
					switch(LevelEditor.instance.tileSelected)
					{
						case LevelEditor.TileSelected.Floor:
						{
							Vector3 position = view.origin;
							position.y = 0;
							Instantiate(LevelEditor.instance.floor,position,Quaternion.identity);
							LevelEditor.instance.LoadedLevel = GameObject.FindGameObjectsWithTag ("Tiles"); 
							int originX = Mathf.FloorToInt(view.origin.x);
							int originY = Mathf.FloorToInt(view.origin.z);
							LevelEditor.instance.currentLevel.SetPixel(originX,originY,LevelEditor.instance.FloorWhite);	
							break;
						}
						case LevelEditor.TileSelected.Delete:
						{
							Vector3 position = view.origin;
							position.y = 0;
							Instantiate(LevelEditor.instance.gridSquare,position,Quaternion.identity);
							LevelEditor.instance.LoadedLevel = GameObject.FindGameObjectsWithTag ("Tiles"); 
							int originX = Mathf.FloorToInt(view.origin.x);
							int originY = Mathf.FloorToInt(view.origin.z);
							LevelEditor.instance.currentLevel.SetPixel(originX,originY,Color.clear);									
							break;
						}
						case LevelEditor.TileSelected.Enter:
						{
							Vector3 entryDoorOffset = Vector3.zero + new Vector3(view.origin.x +0.497f,0.547f,view.origin.z);
							Instantiate(LevelEditor.instance.LevelEnterDoor,entryDoorOffset,Quaternion.identity);
							LevelEditor.instance.LoadedLevel = GameObject.FindGameObjectsWithTag ("Tiles"); 
							int originX = Mathf.FloorToInt((view.origin.x));
							int originY = Mathf.FloorToInt(view.origin.z);
							LevelEditor.instance.currentLevel.SetPixel(originX,originY,LevelEditor.instance.EnterDoorGreen);	
							break;
						}
						case LevelEditor.TileSelected.Exit:
						{
							Vector3 exitDoorOffset = Vector3.zero + new Vector3(view.origin.x,0.526f,view.origin.z - 0.497f);
							Instantiate(LevelEditor.instance.LevelExitDoor,exitDoorOffset,Quaternion.identity);
							LevelEditor.instance.LoadedLevel = GameObject.FindGameObjectsWithTag ("Tiles"); 
							int originX = Mathf.FloorToInt(view.origin.x);
							int originY = Mathf.FloorToInt((view.origin.z+0.397f));
							LevelEditor.instance.currentLevel.SetPixel(originX,originY,LevelEditor.instance.ExitDoorRed);
							break;
						}
						case LevelEditor.TileSelected.Wall:
						{
						Destroy(view.gameObject);
						
							Vector3 wallOffset = Vector3.zero + new Vector3(view.origin.x,0.547f,view.origin.z);
							Instantiate(LevelEditor.instance.wall,wallOffset,Quaternion.identity);
							LevelEditor.instance.LoadedLevel = GameObject.FindGameObjectsWithTag ("Tiles"); 
							int originX = Mathf.FloorToInt(view.origin.x);
							int originY = Mathf.FloorToInt(view.origin.z);
							LevelEditor.instance.currentLevel.SetPixel(originX,originY,LevelEditor.instance.WallGrey);									
							break;
						}
					}	
					LevelEditor.instance.currentLevel.Apply(false,false);
					break;
			
			case TriggerEvent.RightClick:
				//Debug.Log ("Right Click");
			
				break;
				
			default:
				break;
		}
	}

	
}