using UnityEngine;
using System.Collections;

public class posballcomp : MonoBehaviour {


	public Vector3 defaultsize;
	public float decreasespeed = 0f;
	public Vector3 currentsize;
	public float finalsize = .1f;

	public bool tosmall = false;

	//ball energy
	public float energylevel=0f;

	// Use this for initialization
	void Start () {
		defaultsize = transform.localScale;
		currentsize = defaultsize;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void lookedat()
	{
		if(currentsize.z <= finalsize)
		{

			Destroy(transform.gameObject);
			return;
		}


		currentsize.z =transform.localScale.z - (decreasespeed * Time.deltaTime);
		currentsize.x =transform.localScale.x - (decreasespeed * Time.deltaTime);
		currentsize.y =transform.localScale.y - (decreasespeed * Time.deltaTime);
		transform.localScale = currentsize;


	}

}
