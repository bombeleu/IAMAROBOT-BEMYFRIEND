using UnityEngine;
using System.Collections;

public class AlphaLogo : MonoBehaviour {
	
	public float timeToAppear;
	public bool appeared;
	public Color alpha;
	public Color full;
	public bool cmds=false;
	public bool ram=false;
	public bool os=false;
	public bool starting=false;
	public bool please=false;
	
	
	// Use this for initialization
	void Start () {
		GetComponent<GUITexture>().color = alpha;
		GetComponent<GUITexture>().pixelInset.Set(20.0f,Screen.height/3,Screen.height*0.24f,Screen.width*0.14f);
		
		appeared = false;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<GUITexture>().color = alpha;
		GetComponent<GUITexture>().pixelInset.Set(20.0f,Screen.height/3,Screen.height*0.24f,Screen.width*0.14f);
	if( timeToAppear > 0)
		{
			timeToAppear = timeToAppear-Time.deltaTime;
		}
		else
		{
			if(alpha.a < 1)
			{alpha.a = alpha.a + (Time.deltaTime*0.1f);}
			if(alpha.a >= 0.4)
			{
				appeared = true;
				DebugConsoleMenu.IsOpen = true;
			}
				if(alpha.a >= 0.44 && cmds != true)
				{
				DebugConsoleMenu.Log("/Loading CMDS ",DebugConsoleMenu.MessageTypes.System);
				cmds = true;
				}
				if(alpha.a >= 0.52&&  ram != true)
				{
				DebugConsoleMenu.Log("/RAM OK ", DebugConsoleMenu.MessageTypes.System );
				ram = true;
				}
				if(alpha.a >= 0.55&&  os != true)
				{
				DebugConsoleMenu.Log( "/OS Initialised ", DebugConsoleMenu.MessageTypes.System);
				os = true;
				}
				if(alpha.a >= 0.6&&  starting != true)
				{
				DebugConsoleMenu.Log("//////////STARTING/////////// ");
				starting = true;
				}
				if(alpha.a >= 0.75&&  please != true)
				{
				DebugConsoleMenu.Log("PLEASE LOGIN...  ", DebugConsoleMenu.MessageTypes.System);
				please = true;
				}
		}
	}
}
