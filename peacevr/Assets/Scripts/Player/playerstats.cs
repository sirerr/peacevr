using UnityEngine;
using System.Collections;

public class playerstats : MonoBehaviour {

	public float playerhealth = 0f;
	public float playerenergy = 0f;
	public float playerenergylimit = 0f;

	private playercontrol playercontrolref;

	// Use this for initialization
	void Start () {
	
		playercontrolref = transform.GetComponent<playercontrol>();

	}
	
	// Update is called once per frame
	void Update () {
		if(playerenergy<0)
		{
			playerenergy = 0;
		}

		}
	public void energychanges()
	{
	

		if(playerenergy>=playerenergylimit)
		{
			playerenergy = playerenergylimit;
			playercontrolref.energygathering = 0;
		}else
		{
			playerenergy = playercontrolref.energygathering;
		}

	
	}

}

