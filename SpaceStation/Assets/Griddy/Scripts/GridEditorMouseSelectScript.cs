using UnityEngine;
using System.Collections;

public class GridEditorMouseSelectScript : MonoBehaviour {
	
	
	 public GridController controller;
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	void StartHover()
	{
	Debug.Log("startHover Emptygrid tile");	
	this.controller.view.SetState(ViewState.Acceptable);
	}
	void StopHover()
	{
	Debug.Log("stopHover Emptygrid tile");
	this.controller.view.SetState (ViewState.Default);
		
	}
	void LeftClick()
	{
		
	}
	void RightClick()
	{
		
	}
	// Update is called once per frame
	void Update () {
	
	}
}
