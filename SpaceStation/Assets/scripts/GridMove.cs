using System.Collections;
using UnityEngine;

class GridMove : MonoBehaviour {
    public float moveSpeed = 3f;
	public float turnSpeed = 0.1f;
    private float gridSize = 1f;
    private enum Orientation {
        Horizontal,
        Vertical
    };
    private Orientation gridOrientation = Orientation.Horizontal;
    private bool allowDiagonals = false;
    private bool correctDiagonalSpeed = true;
    public Vector2 input;
    public bool isMoving = false;
    private Vector3 startPosition;
	private Quaternion startRotation;
    private Vector3 endPosition;
	private Quaternion endRotation;
    private float t;
    private float factor;
	public float inputMovement; // 1 = forward .   -1 == Backward
	public enum inputRotation{N,E,S,W};
	public inputRotation Rotation;
	public enum inputRotationDirection{Left,Right,none};
	public inputRotationDirection Facing;
	public int magnitude;
	public bool isRotating = false;
	//public float rotatingTimerDebug = 10.0f;
	public int RotDir = 0; //-1 = right , +1 = left
	public int MoveForwardCount = 0;
	public int MoveBackwardCount = 0;
	
	public void Start()
	{
		Rotation = inputRotation.E;
		Facing = inputRotationDirection.none;
	}
	
	public void TurnRight()
	{
		Facing = inputRotationDirection.Right;
	}
	public void TurnLeft()
	{
		Facing = inputRotationDirection.Left;
	}
	public void MoveForward(int moves)
	{
		inputMovement = 1;
		MoveForwardCount = moves;
		isMoving = false;
	}
	public void MoveBackward(int moves)
	{
		inputMovement = -1;
		MoveBackwardCount = moves;
		isMoving = false;
	}
	
	
	
	
    public void Update() 
	{
        if (!isMoving) 
		{
            //input = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
			//Debug.Log(input);
			//inputMovement = input.y;
			//Debug.Log(inputMovement);
			if(inputMovement == 1)
						{
				           // if (!allowDiagonals){if (Mathf.Abs(input.x) > Mathf.Abs(input.y)){input.y = 0;}else{input.x = 0;}}
				            StartCoroutine(move(transform));
						}
			if(inputMovement == -1)
						{
							// if (!allowDiagonals){if (Mathf.Abs(input.x) > Mathf.Abs(input.y)){input.y = 0;}else{input.x = 0;}}
				            StartCoroutine(move(transform));
						}
		}
		if(!isRotating)
			{
			
				if (Facing != inputRotationDirection.none)
					{
						//StartCoroutine(rotate(transform));
						if(Facing == inputRotationDirection.Right) //right
						{
							startRotation = transform.rotation;
							endRotation = transform.rotation;
							endRotation.y = 90f;
							switch (Rotation){
							case inputRotation.E: {Rotation = inputRotation.S; isRotating = true; break;}
							case inputRotation.N: {Rotation = inputRotation.E; isRotating = true; break;}
							case inputRotation.S: {Rotation = inputRotation.W; isRotating = true; break;}
							case inputRotation.W: {Rotation = inputRotation.N; isRotating = true; break;}
							}
							
						}
						else if(Facing == inputRotationDirection.Left) //left
						{
							startRotation = transform.rotation;
							endRotation = transform.rotation;
							endRotation.y = -90f;
							switch (Rotation){
							case inputRotation.E: {Rotation = inputRotation.N; isRotating = true; break;}
							case inputRotation.N: {Rotation = inputRotation.W; isRotating = true; break;}
							case inputRotation.S: {Rotation = inputRotation.E; isRotating = true; break;}
							case inputRotation.W: {Rotation = inputRotation.S; isRotating = true; break;}
							}
							
						}
						//Debug.Log(endRotation);
						transform.Rotate(Vector3.up,endRotation.y);
						Facing = inputRotationDirection.none;
						isRotating = false;
					}
		}
	}
	
	/*
	public IEnumerator rotate(Transform transform) {
		
		startRotation = transform.rotation;
		 startPosition = transform.position;
		//t = 0;
			//Debug.Log(inputRotationDirection);
				if(inputRotationDirection == -1) // Turn Right 
				{
					RotDir = -1;
					switch (Rotation){
						case inputRotation.E: {Rotation = inputRotation.S; isRotating = true; break;}
						case inputRotation.N: {Rotation = inputRotation.E; isRotating = true; break;}
						case inputRotation.S: {Rotation = inputRotation.W; isRotating = true; break;}
						case inputRotation.W: {Rotation = inputRotation.N; isRotating = true; break;}
						}
					//input.x = 0;
				}
				else if(inputRotationDirection == 1)  //Turn Left
				{
					RotDir = 1;
					switch (Rotation){
						case inputRotation.E: {Rotation = inputRotation.N; isRotating = true; break;}
						case inputRotation.N: {Rotation = inputRotation.W; isRotating = true; break;}
						case inputRotation.S: {Rotation = inputRotation.E; isRotating = true; break;}
						case inputRotation.W: {Rotation = inputRotation.S; isRotating = true; break;}
						}
					//input.x = 0;
				}
		
		//factor = 1f;
		//if(RotDir == true){endRotation = startRotation; endRotation.y+=90.0f;}
		//if(RotDir == false){endRotation = startRotation; endRotation.y-=90.0f;}
		//if(RotDir == 1){endRotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y +90f,0);}
		//else if(RotDir == -1){endRotation = Quaternion.Euler(0,transform.rotation.eulerAngles.y -90f,0);}
		//Debug.Log(endRotation);
		
         	if(RotDir == 1)
			{transform.rotation.Set(endRotation.x,endRotation.y+90,endRotation.z,endRotation.w);}
			if(RotDir == -1)
			{transform.rotation.Set(endRotation.x,endRotation.y+90,endRotation.z,endRotation.w);}
		
		
		while (transform.rotation != endRotation)  
		{
			transform.rotation = endRotation;
			// Quaternion.Slerp(startRotation, endRotation, moveSpeed);
			
            yield return null;
        }
		if(transform.rotation == endRotation){isRotating = false;inputRotationDirection = 0;RotDir = 0;}
		
		if(transform.rotation == endRotation || ((transform.rotation.y <= (endRotation.y+10)) && (transform.rotation.y >= (endRotation.y -10))))
		{
		isRotating = false;
		transform.rotation = endRotation;
			inputRotationDirection = 0;
		}
		
        yield return 0;
	}
	*/
	

    public IEnumerator move(Transform transform) {
        isMoving = true;
        startPosition = transform.position;
        t = 0;
		
		
		//SET THIS UP TO ALLOW FOR REVERSE MOVEMENT AND ALTERNATE ORIENTATION OF GRID.
        if(gridOrientation == Orientation.Horizontal) {
			if(inputMovement == 1) //Forwards
			{	
				if(MoveForwardCount >=0)
				{
				switch(Rotation)
				{
					case inputRotation.W:{endPosition = new Vector3((startPosition.x + 0f) * gridSize,startPosition.y, (startPosition.z+ 1f) * gridSize);break;}
					case inputRotation.N:{endPosition = new Vector3((startPosition.x + 1f) * gridSize,startPosition.y, (startPosition.z+ 0f) * gridSize);break;}
					case inputRotation.S:{endPosition = new Vector3((startPosition.x - 1f) * gridSize,startPosition.y, (startPosition.z+ 0f) * gridSize);break;}
					case inputRotation.E:{endPosition = new Vector3((startPosition.x + 0f) * gridSize,startPosition.y, (startPosition.z- 1f) * gridSize);break;}
				}
					MoveForwardCount --;
				}
				else{inputMovement = 0;}
			}
			if(inputMovement == -1)	//Backwards
			{
				if(MoveBackwardCount >0)
				{
				switch(Rotation)
				{
					case inputRotation.W:{endPosition = new Vector3((startPosition.x + 0f) * gridSize,startPosition.y, (startPosition.z- 1f) * gridSize);break;}
					case inputRotation.N:{endPosition = new Vector3((startPosition.x - 1f) * gridSize,startPosition.y, (startPosition.z+ 0f) * gridSize);break;}
					case inputRotation.S:{endPosition = new Vector3((startPosition.x + 1f) * gridSize,startPosition.y, (startPosition.z+ 0f) * gridSize);break;}
					case inputRotation.E:{endPosition = new Vector3((startPosition.x + 0f) * gridSize,startPosition.y, (startPosition.z+ 1f) * gridSize);break;}
				}
					MoveBackwardCount --;
				}
				else{inputMovement = 0;}
			}
            /*endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y, startPosition.z + System.Math.Sign(input.y) * gridSize);*/
        } else {
            /*endPosition = new Vector3(startPosition.x + System.Math.Sign(input.x) * gridSize,
                startPosition.y + System.Math.Sign(input.y) * gridSize, startPosition.z);*/
        }

        if(allowDiagonals && correctDiagonalSpeed && input.x != 0 && input.y != 0) {
            factor = 0.7071f;
        } else {
            factor = 1f;
        }

        while (t < 1f) {
            t += Time.deltaTime * (moveSpeed/gridSize) * factor;
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
            yield return null;
        }

        isMoving = false;
		inputMovement = 0;
        yield return 0;
    }
}