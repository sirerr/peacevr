using UnityEngine;
using System.Collections;

public class playercontrol : MonoBehaviour {

	public bool touchpadinput = false;
	public bool backbuttoninput = false;

	//raycast length
	public float raydistance =0;
	//ball layermask
	public LayerMask ballmask = 1<<8;

	private playerstats playerstatref;

	//ballinfo
	public float energygathering = 0;
	 //waitamount
	public float waitamount = 10f;

	//the hit location of the raycast
	public Vector3 hitlocation;

	// Use this for initialization
	void Start () {
		playerstatref = transform.GetComponent<playerstats>();

	}
	
	// Update is called once per frame
	void Update () {
	

//		if(playerstatref.playerenergy< playerstatref.playerenergylimit){
//			playerstatref.playerenergy = energygathering;
//		}else
//		{
//			energygathering =0;
//		}

		touchpadinput = Input.GetMouseButton(0);
		backbuttoninput = Input.GetMouseButton(1);

		//raycast area
		Debug.DrawRay(transform.position,transform.TransformDirection(Vector3.forward * raydistance), Color.red, .1f);

		if(touchpadinput)
		{

			RaycastHit lookerhit;
		//	print("looking for ball");
			
			Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward),out lookerhit,raydistance,ballmask);

			if(lookerhit.collider == null)
			{
				return;
			}

			hitlocation = lookerhit.transform.position;

			if(lookerhit.transform.tag == "energyball")
			{
				StartCoroutine(energygather());
				energygathering += lookerhit.transform.GetComponent<posballcomp>().energylevel;
//				playerstatref.energychanges();
				lookerhit.transform.gameObject.SendMessage("lookedat");
			}

			if(lookerhit.transform.tag == "areatop")
			{
				GameObject parentarea;

				parentarea = lookerhit.transform.root.gameObject;

				if(playerstatref.playerenergy> 0f)
				{
					StartCoroutine(areabeamwait());
					parentarea.SendMessage("playerrayhit");
				}
			
			}

		}

	}

	IEnumerator energygather()
	{
		yield return new WaitForSeconds(waitamount);
//		energygathering += lookerhit.transform.GetComponent<posballcomp>().energylevel;
		playerstatref.energychanges();
	//	lookerhit.transform.gameObject.SendMessage("lookedat");

	}

	IEnumerator areabeamwait()
	{
		//print (playerstatref.playerenergy);
		yield return new WaitForSeconds(waitamount);
		playerstatref.playerenergy = playerstatref.playerenergy -1f;

	}
}
