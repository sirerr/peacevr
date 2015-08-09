using UnityEngine;
using System.Collections;

public class negareacomp : MonoBehaviour {

	//power level of the area
	public float negstrength = 0;
	//currentcolor
	public Color currentcolor;
	//newcolor
	public Color newcolor;

	// location of the floor
	public float flooryloc=0;
	//render ref
	public Renderer arearen;

	//waittime
	public float waittime =0;
	public float areadeathtime =5f;

	//fallspeed
	public float fallspeed =0;

	//gamemangerref
	public gamemanager gamemanagerref;

	private	void onAwake()
	{

	}

	// Use this for initialization
	void Start () {
	
		currentcolor = GetComponent<Renderer>().material.color;
		arearen = GetComponent<Renderer>();
		flooryloc = GameObject.Find("floor").transform.position.y;
	
	}
	
	// Update is called once per frame
	void Update () {
	if(Mathf.Abs(transform.position.y)>= flooryloc)
		{
			transform.Translate(0,-fallspeed * Time.deltaTime,0);
		}
	}

	public void playerrayhit()
	{
		//print ("ray hitting top part in order to change the area");
		StartCoroutine(decnegstrength());

		if(negstrength<=0f){
		arearen.material.color = newcolor;
			StartCoroutine(destroyarea());
		}
		//change color possibly a coorutine
	}

	IEnumerator decnegstrength()
	{
		yield return new WaitForSeconds(waittime);
		negstrength--;
	}

	IEnumerator destroyarea()
	{
		yield return new WaitForSeconds(areadeathtime);
		Destroy (transform.gameObject);
	}
}
