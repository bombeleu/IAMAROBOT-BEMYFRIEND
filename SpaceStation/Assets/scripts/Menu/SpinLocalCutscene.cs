using UnityEngine;
using System.Collections;

public class SpinLocalCutscene : MonoBehaviour {
	
	public float speed;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	transform.Rotate(Vector3.up,speed * Time.deltaTime);
	transform.Rotate(Vector3.left,(speed * Time.deltaTime)/50);
	}
}
