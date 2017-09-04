using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;

public class test2Script : MonoBehaviour {

	// Use this for initialization
	public Vector3 mousePosition, targetPosition;
	public GameObject cuboPrefab;
	private float distance = 10f;
	public Toggle desactiva;
	public GameObject[] cubos;
	public Text fpsText;
	public Text colisionText;
	public int fpsRate;
	public static int contador_colisiones = 0;

	void Start () {
		contador_colisiones = 0;
	}

	// Update is called once per frame
	void Update () {
		fpsRate = (int)(1f / Time.unscaledDeltaTime);
		fpsText.text = "F P S: " + fpsRate;
		colisionText.text = "Colisiones: " + contador_colisiones;
		if (desactiva.isOn == true) {
			cubos = GameObject.FindGameObjectsWithTag ("prueba");
			foreach (var item in cubos) {
				item.GetComponent<Rigidbody2D> ().freezeRotation = true;
			}
		} else {
			cubos = GameObject.FindGameObjectsWithTag ("prueba");
			foreach (var item in cubos) {
				item.GetComponent<Rigidbody2D> ().freezeRotation = false;
			}
		}
		if (Input.GetKeyDown(KeyCode.S)) {
			if (desactiva.isOn == true) {
				desactiva.isOn = false;
			}else {
				desactiva.isOn = true;
			}
		}
			
		if (Input.GetButtonDown("Fire1"))
		{
			mousePosition = Input.mousePosition;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);        
			targetPosition=Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x,mousePosition.y,distance));
			cuboPrefab.transform.position = targetPosition;
			//Debug.Log ("mouse position: " + "x: "+Input.mousePosition.x +"y: "+Input.mousePosition.y);
			//Debug.Log ("entro a fire1");
			Instantiate (cuboPrefab, new Vector2(cuboPrefab.transform.position.x, cuboPrefab.transform.position.y), transform.rotation);
		}
	}
}