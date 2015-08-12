using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class negareacomp : MonoBehaviour {

	//power level of the area
	public float negstrength = 0;
	//area percent
	public float areanegpercent = 0;
	// percent limit
	public float percentlimit = 0;
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
	// ui game ref
	public UIcode uicoderef;

	private	void onAwake()
	{

	}

	// Use this for initialization
	void Start () {
	
		currentcolor = GetComponent<Renderer>().material.color;
		arearen = GetComponent<Renderer>();
		flooryloc = GameObject.Find("floor").transform.position.y;
		uicoderef = GameObject.Find("canvas0").transform.GetComponent<UIcode>();
		areanegpercent = Mathf.Abs(Random.Range(0,percentlimit));
	
		uicoderef.negamount += areanegpercent;
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
		uicoderef.negamount -= areanegpercent;
	
		Destroy (transform.gameObject);
	}
}
