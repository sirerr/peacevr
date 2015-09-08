using UnityEngine;
using System.Collections;

public class enemyaction : MonoBehaviour {

	//area to limit movement too
	public float xposarealimit=5f;
	public float xnegarealimit=-5f;
	public float znegarealimit = 0f;
	//ending loc
	public Vector3 endingloc;
	public float stepspeed=0;
	//
	public float waittimefromattack =0;
	//faceobjs
	public GameObject faceobj;
	public GameObject backfaceobj;
	//wait time before creating area
	public float randomwaittime=0;
	public float waitrange1;
	public float waitrange2;
	//the area obj;
	public GameObject areaobj;
	public GameObject newarea;
	//check to see where you are
	public bool atreststop = false;
	public bool areadropped = false;
	//statemachine var
	public int intstate=4;

	/// <summary>
	/// The idea of the next few variables is to the action after creating the bubble
	/// </summary>
	public Transform playertrans;
	//enemy stats ref
	private enemystats enemystatsref;
	public float enemystrength =0;

	//reference areas
	public gamemanager gamemanagerref;

	//

	private void Awake()
	{
		faceobj = transform.GetChild(0).gameObject;
		backfaceobj = faceobj.transform.GetChild(0).gameObject;
		endingloc = new Vector3 (Random.Range(xnegarealimit,xposarealimit),transform.position.y,Random.Range(znegarealimit,transform.position.z));
		randomwaittime = Random.Range(waitrange1,waitrange2);
		intstate =1;
		//test code
		gamemanagerref =  GameObject.FindGameObjectWithTag("GameController").GetComponent<gamemanager>();
		//test code
		playertrans = GameObject.FindGameObjectWithTag("Player").transform;
		enemystatsref = GetComponent<enemystats>();
		enemystrength = enemystatsref.enemynegstrength;

	}

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	

		switch (intstate)
		{
		case 0:
			if(newarea == null)
			{
				intstate = 3;
			}
			break;

		case 1:
			transform.position = Vector3.MoveTowards(transform.position,endingloc,stepspeed);
			if(transform.position == endingloc)
			{
				atreststop = true;
				intstate = 2;

			}
			break;
		case 2:
			if(atreststop)
			{
				atreststop = false;
				StartCoroutine(dropbubble());
			}
			break;
		case 3:
			faceobj.transform.LookAt(playertrans);

			if(!areadropped)
			{
				StartCoroutine(dropbubble());
			}
			break;
		}
	
//
//		if(transform.position != endingloc)
//		{
//			transform.position = Vector3.MoveTowards(transform.position,endingloc,stepspeed);
//
//		}else if(transform.position == endingloc)
//		{
//			atreststop = true;
//			transform.position = new Vector3(transform.position.x + .5f,transform.position.y +.5f,transform.position.z +.5f);
//		}
//
//		if(atreststop)
//		{
//			atreststop = false;
//			StartCoroutine(dropbubble());
//		}

	}

	IEnumerator dropbubble()
	{

		newarea = Instantiate(areaobj,transform.position,Quaternion.identity) as GameObject;
		newarea.GetComponent<negareacomp>().gamemanagerref = gamemanagerref;
		areadropped = true;
		intstate =0;
		yield return new WaitForSeconds(randomwaittime);

	//	transform.GetComponent<enemybehavoir>().enabled = true;
	}

	public void beingattacked()
	{
		print ("player attacking me");
		intstate = 3;


		if(enemystatsref.enemynegstrength>0)
		{
			enemystatsref.enemynegstrength--;
			
			if(enemystatsref.enemynegstrength<=0)
			{
				transform.GetComponent<BoxCollider>().enabled = false;
				Destroy(gameObject,1f);
			}
		}
		else
		{
			return;
		}

	}

//	IEnumerator decreasenegstrength()
//	{
//		yield return new WaitForSeconds(waittimefromattack);
//		enemystatsref.enemynegstrength--;
//
//		if(enemystatsref.enemynegstrength<=0)
//		{
//			transform.GetComponent<BoxCollider>().enabled = false;
//			Destroy(gameObject,1f);
//		}
//	}

void OnDisable()
	{
		gamemanagerref.defeatedenemies++;
	}

//	IEnumerator deathcor()
//	{
//		yield return new WaitForSeconds(1f);
//		gamemanagerref.defeatedenemies = gamemanagerref.defeatedenemies +1;
//		Destroy(gameObject);
//
//	}
}
