using UnityEngine;
using System.Collections;

public class enemyspawn : MonoBehaviour {

	public GameObject spawnlocobj;
	public GameObject[] faceobjs;
	public int spawnnum = 0;

	//amount of faces
	public int faceamount = 0;
	//reference to game manager
	public gamemanager gamemangerref;
	//gate opening obj
	public GameObject facegateobj;
	//wait time one
	public float waittime1 = 0;
	public float waittime2 = 0;
	public float waittime3 = 0;

	// Use this for initialization
	void Start () {
		spawnlocobj = GameObject.FindGameObjectWithTag("spawnloc");
		gamemangerref = GetComponent<gamemanager>();
		StartCoroutine(levelstart());
		faceamount = faceobjs.Length;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator levelstart()
	{
		yield return new WaitForSeconds (waittime1);
		//make the facegate obj active
		//wait for a few seconds
		//create the first enemy
		Instantiate(faceobjs[spawnnum],spawnlocobj.transform.position,Quaternion.identity);
		spawnnum++;
		yield return new WaitForSeconds(waittime2);
		newenemy();

	}

	IEnumerator quickwait()
	{
		yield return new WaitForSeconds(waittime2);
		newenemy();
	}

	public void newenemy()
	{
		if(spawnnum<=faceobjs.Length-1)
		{
			Instantiate(faceobjs[spawnnum],spawnlocobj.transform.position,Quaternion.identity);
			spawnnum++;
			StartCoroutine(quickwait());
		}
	
	}

}
