using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour {

	public bool touchpadinput = false;
	public bool backbuttoninput = false;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
		touchpadinput = Input.GetMouseButton(0);
		backbuttoninput = Input.GetMouseButton(1);

	}
}
