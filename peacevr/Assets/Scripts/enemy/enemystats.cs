using UnityEngine;
using System.Collections;

public class enemystats : MonoBehaviour {

	public float enemynegstrength = 0;
	//values
	public float madfloat = 0;
	public float mellowfloat = 0;
	public float happyfloat =0;
	public float moodpercentage = .45f;

	//animations for the faces
	public Animation madanim;
	public Animation mellowanim;
	public Animation happyanim;

	//colors for the enemy
	public Material madcolor;
	public Material mellowcolor;
	public Material happycolor;

	//reference

	private enemyaction enemyactionref;

	// Use this for initialization
	void Start () {
		enemyactionref = GetComponent<enemyaction>();
		madfloat = enemynegstrength - (enemynegstrength * moodpercentage );
		mellowfloat = enemynegstrength - (enemynegstrength * (moodpercentage *2));
	}
	
	// Update is called once per frame
	void Update () {
	
		if(enemynegstrength>madfloat)
		{
			enemyactionref.faceobj.GetComponent<Renderer>().material = madcolor;
			enemyactionref.backfaceobj.GetComponent<Renderer>().material = madcolor;
		}

		if(enemynegstrength>mellowfloat && enemynegstrength<madfloat)
		{
			enemyactionref.faceobj.GetComponent<Renderer>().material = mellowcolor;
			enemyactionref.backfaceobj.GetComponent<Renderer>().material = mellowcolor;
		}

		if(enemynegstrength>happyfloat && enemynegstrength <mellowfloat)
		{
			enemyactionref.faceobj.GetComponent<Renderer>().material = happycolor;
			enemyactionref.backfaceobj.GetComponent<Renderer>().material = happycolor;
		}


	}
}
