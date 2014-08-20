using UnityEngine;
using System.Collections;

public class currentLevelGUI : MonoBehaviour {
	
	public GUITexture currentguiTexture;
	private float Twidth;
	private float Theight;
	private float TxPos;
	private float TyPos;
	private float Swidth;
	private float Sheight;
	
	// Use this for initialization
	void Start () {
		Swidth = Screen.width;
		Sheight = Screen.height;
		
		if(currentguiTexture.texture != null)
		{
		Twidth = currentguiTexture.texture.width;
		Theight = currentguiTexture.texture.height;
		TxPos = 1/(Swidth - Twidth);
		TyPos = 1/((Sheight - Theight)-10);
		currentguiTexture = this.gameObject.guiTexture;
		currentguiTexture.guiTexture.transform.Translate(TxPos,TyPos,0);
		}
	
	}
	public void SetGuiTexture()
	{
		currentguiTexture.texture = LevelEditor.instance.currentLevel;
		currentguiTexture.texture.anisoLevel =  9;
		currentguiTexture.texture.filterMode = FilterMode.Point;
		currentguiTexture.texture.mipMapBias = -0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		Swidth = Screen.width;
		Sheight = Screen.height;
		if(currentguiTexture.texture != null)
		{
		Twidth = currentguiTexture.texture.width;
		Theight = currentguiTexture.texture.height;
		TxPos = 1/(Swidth - Twidth);
		TyPos = 1/((Sheight - Theight)-10);
		currentguiTexture.guiTexture.transform.position.Set(TxPos,TyPos,0);
		currentguiTexture.transform.localScale.Set(0.2f,0.36f,1f);
		}
		
	
	}
}
