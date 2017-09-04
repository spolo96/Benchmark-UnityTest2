using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class contadorColi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D enter) {
		if (enter.gameObject.tag == "prueba") {
			test2Script.contador_colisiones++;
		}
	}

}
