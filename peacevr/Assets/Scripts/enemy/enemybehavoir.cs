using UnityEngine;
using System.Collections;

public class enemybehavoir : MonoBehaviour {

	//player location
	public Transform playertrans;
	//look at player or not
	public bool lookatplayer = false;


	// Use this for initialization
	void Start () {
		playertrans = GameObject.FindGameObjectWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	

		if(lookatplayer)
		{
			transform.LookAt(playertrans.position);
		}

	}
}
