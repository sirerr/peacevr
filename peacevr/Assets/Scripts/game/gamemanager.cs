using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class gamemanager : MonoBehaviour {

	private UIcode uicoderef;
	//bool for over amount
	public bool itsover = false;
	//int for states
	public int gamestate=1;
	// the timer
	public int gametimer =0;
	// the text in the timer
	public Text gametimertext;
	//the game limit
	public int gametimelimit =0;


	// Use this for initialization
	void Start () {
		uicoderef = GameObject.Find("canvas0").GetComponent<UIcode>();
	
		StartCoroutine(corgametimer());
	}

	IEnumerator corgametimer()
	{
		yield return new WaitForSeconds(.01f);
		gametimertext = uicoderef.timer.GetComponent<Text>();
		while (gametimer<=gametimelimit)
		{
			yield return new WaitForSeconds(1f);
			gametimer++;
			gametimertext.text = gametimer.ToString();
		}
		itsover = true;
		gamestate = 0;
	}
	
	// Update is called once per frame
	void Update () {
	
		//check to see if 
		if(uicoderef.negamount > 100f)
		{
			uicoderef.negamount = 100f;
			itsover = true;
			gamestate =0;
		}

		switch (gamestate)
		{
			case 0:
			if(itsover)
			{
				itsover =false;
				gamestate  = 5;
				//do courotine here to end the game
			}
			break;
			case 1:
			break;
		}
	}
}
