using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	
	public GameObject Startposition;
	public GameObject Endposition;
	public float speed;
	public Vector3 smoothpos;
	public Vector3 currentheading;
	// Use this for initialization
	void Start () {
	transform.position = Startposition.transform.position;
		
		
	}
	void FixedUpdate()
	{
		smoothpos = Endposition.transform.position - transform.position;
		
		currentheading = Vector3.Lerp(currentheading,smoothpos,Time.deltaTime*speed);
	}
	
	// Update is called once per frame
	void Update () {
		
		
		transform.position += currentheading * Time.deltaTime;
		
	}
}
