using UnityEngine;
using System.Collections;

public class enemyspawn : MonoBehaviour {

	public GameObject spawnlocobj;

	// Use this for initialization
	void Start () {
		spawnlocobj = GameObject.FindGameObjectWithTag("spawnloc");


	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
