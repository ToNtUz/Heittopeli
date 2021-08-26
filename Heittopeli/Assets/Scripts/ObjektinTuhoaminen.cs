using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjektinTuhoaminen : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision osuttiin)
		{
			Debug.Log("osuttiin johonkin" + osuttiin.gameObject.name);
			Destroy(this.gameObject, 2f );
		}
	
}