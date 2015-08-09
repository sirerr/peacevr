using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIcode : MonoBehaviour {

	public RawImage energybarobj;
	public Texture[] energybars;
	//playerref
	public playerstats playerstatsref;
	public float energylevel=0;
	public int intenergylevel =0;
	public Texture zerolevel;

	// Use this for initialization
	void Start () {
	
		energybarobj.texture = zerolevel;
	}
	
	// Update is called once per frame
	void Update () {
	
		energylevel = Mathf.Abs(playerstatsref.playerenergy/10f);
		intenergylevel = Mathf.FloorToInt(energylevel);


		switch(intenergylevel)
		{
		case 10:
			energybarobj.texture = energybars[9];
			break;
		case 9:
			energybarobj.texture = energybars[8];
			break;
		case 8:
			energybarobj.texture = energybars[7];
			break;
		case 7:
			energybarobj.texture = energybars[6];
			break;
		case 6:
			energybarobj.texture = energybars[5];
			break;
		case 5:
			energybarobj.texture = energybars[4];
			break;
		case 4:
			energybarobj.texture = energybars[3];
			break;
		case 3:
			energybarobj.texture = energybars[2];
			break;
		case 2:
			energybarobj.texture = energybars[1];
			break;
		case 1:
			energybarobj.texture = energybars[0];
			break;
		default:
			energybarobj.texture = zerolevel;
			break;
		}

	}
}
