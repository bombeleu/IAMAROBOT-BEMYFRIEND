using UnityEngine;
using System.Collections;

public class TestLevelLoad : MonoBehaviour {

	// Use this for initialization
	void Start () {
	GridGenerator.instance.GenerateCurrentLevel(Vector3.zero);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
