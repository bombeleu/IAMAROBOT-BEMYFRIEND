using UnityEngine;
using System.Collections;

public class GridCamera : MonoSingleton<GridCamera>
{
	public bool isActive = false;
	GridTrigger trigger = null;
	public GameObject Robot;
	public Vector3 RobotviewPos;
	
	public Vector2 input;
	public enum e_CameraMode{Play,Edit};
	public e_CameraMode e_Camera;
	
	public float timeToSnapCamera;
	public float cameraSnapTimeSetting;
	public float cameraSnapSpeed;
	public GameObject desiredCameraPosition;
	public float currentZoomLevel;
	public float nextZoomLevel;
	public float ZoomLevel;
	public float ZoomMax;
	public float ZoomMin;
	
	
	
	
	void Start()
	{
		if(Application.loadedLevelName == "LevelEditor-DEV" || Application.loadedLevelName == "LevelEditor")
		{e_Camera = e_CameraMode.Edit;}
		else{e_Camera = e_CameraMode.Play;}
		currentZoomLevel = ZoomLevel;
		nextZoomLevel = ZoomLevel;
		if(e_Camera == e_CameraMode.Play)
		{
		Robot = GameObject.FindGameObjectWithTag("Robot");
		RobotviewPos = Camera.main.WorldToViewportPoint(Robot.transform.position);	
		desiredCameraPosition = GameObject.FindGameObjectWithTag("desiredCamPos");
		}
			/*float targetaspect = 16.0f / 9.0f;
		    // determine the game window's current aspect ratio
		    float windowaspect = (float)Screen.width / (float)Screen.height;
		    // current viewport height should be scaled by this amount
		    float scaleheight = windowaspect / targetaspect;
		    // obtain camera component so we can modify its viewport
		    Camera camera = GetComponent<Camera>();
		    // if scaled height is less than current height, add letterbox
		    if (scaleheight < 1.0f)
		    {  
		        Rect rect = camera.rect;
		        rect.width = 1.0f;
		        rect.height = scaleheight;
		        rect.x = 0;
		        rect.y = (1.0f - scaleheight) / 2.0f;
		        camera.rect = rect;
		    }
		    else // add pillarbox
		    {
		        float scalewidth = 1.0f / scaleheight;
		        Rect rect = camera.rect;
		        rect.width = scalewidth;
		        rect.height = 1.0f;
		        rect.x = (1.0f - scalewidth) / 2.0f;
		        rect.y = 0;
		        camera.rect = rect;
		    }*/
	}
	
	
	void Update()
	{
		
		
		if(e_Camera == e_CameraMode.Edit)
		{
			/*
			if(Input.mousePosition.y <= (Screen.height/20.0f)){this.transform.Translate(0.0f,-0.1f,0.0f,Space.Self);} //Move Camera Up
			if(Input.mousePosition.y >= ((Screen.height/20.0f)*19)){this.transform.Translate(0.0f,0.1f,0.0f,Space.Self);}//Move Camera Down
			if(Input.mousePosition.x <= (Screen.width/20.0f)){this.transform.Translate(-0.1f,0.0f,0.0f,Space.Self);}	//Move Camera Left
			if(Input.mousePosition.x >= ((Screen.width/20.0f)*19)){this.transform.Translate(0.1f,-0.0f,0.0f,Space.Self);} //Move Camera Right
			*/
			if(Input.GetButton("Fire3"))
			{
				input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
				this.transform.Translate(input.x,input.y,0,Space.Self);
			}
			
			if (Input.GetAxis("Mouse ScrollWheel") > 0 && ZoomLevel >= ZoomMin){ZoomLevel -= 0.20f;}//MouseWheel Zoom
			if (Input.GetAxis("Mouse ScrollWheel") < 0&& ZoomLevel <= ZoomMax){ZoomLevel += 0.20f;}
			Camera.main.orthographicSize = ZoomLevel;
		}
		
		if(e_Camera == e_CameraMode.Play)
		{
			RobotviewPos = Camera.main.WorldToViewportPoint(Robot.transform.position);
			//GET ROBOT POSITION ON SCREEN
		
			/*if(RobotviewPos.y <=  0.9)
			{
				if(Input.mousePosition.y <= (Screen.height/20.0f))
				{
					this.transform.Translate(0.0f,-0.1f,0.0f,Space.Self); //Move Camera Up
				}
			}
			if(RobotviewPos.y >=  0.1)
			{
				if(Input.mousePosition.y >= ((Screen.height/20.0f)*19))
				{
					this.transform.Translate(0.0f,0.1f,0.0f,Space.Self); //Move Camera Down
				}
			}
			
			if(RobotviewPos.x <= 0.9)
			{
				if(Input.mousePosition.x <= (Screen.width/20.0f))
				{
					this.transform.Translate(-0.1f,0.0f,0.0f,Space.Self);	//Move Camera Left
				}
			}
			
			if(RobotviewPos.x >= 0.1)
			{
				if(Input.mousePosition.x >= ((Screen.width/20.0f)*19))
				{
					this.transform.Translate(0.1f,-0.0f,0.0f,Space.Self); //Move Camera Right
				}
			}*/
			
			if(Input.GetButton("Fire3"))
			{
				timeToSnapCamera = cameraSnapTimeSetting;
				input = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
				//this.transform.Translate(input.x,input.y,0,Space.Self);
				desiredCameraPosition.transform.Translate(input.x,input.y,0,Space.Self);
			}
			//Keep Characters on Screen///
			else
			{
			if(timeToSnapCamera <= 0)
				{
//			if(RobotviewPos.x < 0.85){this.transform.Translate(-0.1f,-0.0f,0.0f,Space.Self);}
//			if(RobotviewPos.x > 0.15){this.transform.Translate(0.1f,0.0f,0.0f,Space.Self);}
//			if(RobotviewPos.y < 0.15){this.transform.Translate(-0.0f,-0.1f,0.0f,Space.Self);}
//			if(RobotviewPos.y > 0.85){this.transform.Translate(0.0f,0.1f,0.0f,Space.Self);}	
					
			if(RobotviewPos.x < 0.85){desiredCameraPosition.transform.Translate(-0.1f,-0.0f,0.0f,Space.Self);}
			if(RobotviewPos.x > 0.15){desiredCameraPosition.transform.Translate(0.1f,0.0f,0.0f,Space.Self);}
			if(RobotviewPos.y < 0.15){desiredCameraPosition.transform.Translate(-0.0f,-0.1f,0.0f,Space.Self);}
			if(RobotviewPos.y > 0.85){desiredCameraPosition.transform.Translate(0.0f,0.1f,0.0f,Space.Self);}		
				}
				if(timeToSnapCamera>0){timeToSnapCamera-= Time.deltaTime * 1;}
			}
			transform.position = Vector3.Lerp(transform.position,desiredCameraPosition.transform.position,Time.deltaTime * cameraSnapSpeed);
			
			//////////////////////////////
			//MouseWheel Zoom
			
			if (Input.GetAxis("Mouse ScrollWheel") > 0 && ZoomLevel >= ZoomMin){ZoomLevel -= 0.20f;}
			if (Input.GetAxis("Mouse ScrollWheel") < 0&& ZoomLevel <= ZoomMax){ZoomLevel += 0.20f;}
			
			/*
			//Camera Smooth Zoom - Incomplete
			if (Input.GetAxis("Mouse ScrollWheel") > 0 && ZoomLevel >= ZoomMin)
			{
				if(nextZoomLevel+ 0.60f < ZoomMax)
				{
					nextZoomLevel = (currentZoomLevel + 0.60f);
				}
				
			}
			if (Input.GetAxis("Mouse ScrollWheel") < 0 && ZoomLevel <= ZoomMax)
			{
				if(nextZoomLevel- 0.60f > ZoomMin)
				{
					nextZoomLevel = (currentZoomLevel - 0.60f);
				}
				
			}
			
			if(ZoomLevel > nextZoomLevel-0.10 || ZoomLevel > nextZoomLevel +0.10)
			{
				ZoomLevel = Mathf.Lerp(currentZoomLevel,nextZoomLevel,Time.deltaTime * cameraSnapSpeed);
			}
			else if(ZoomLevel > nextZoomLevel-0.10 || ZoomLevel < nextZoomLevel +0.10)
			{
				currentZoomLevel = ZoomLevel;
				nextZoomLevel = ZoomLevel;
			}
			*/
			//Set Zoom to the zoomlevel
			Camera.main.orthographicSize = ZoomLevel;
		}
        
		
		if(!isActive)
		{
			return;
		}
		
		Ray ray = camera.ScreenPointToRay(Input.mousePosition);

		if(GridDirector.instance.isDebugMode)
		{
			Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
		}
		
		RaycastHit hit = new RaycastHit();
		
		if(trigger != null)
		{
			trigger.StopHover();
			trigger = null;
		}
		
    	if (Physics.Raycast (ray, out hit, 1000)) 
		{
			trigger = hit.collider.gameObject.GetComponent<GridTrigger>();
			
			if(!trigger)
			{
				return;
			}
			
			trigger.StartHover();
			
			if(Input.GetMouseButtonDown(0))
			{
				trigger.OnLeftClick();
			}
			if(Input.GetMouseButtonDown(1))
			{
				trigger.OnRightClick();
			}
		}
    }
}
