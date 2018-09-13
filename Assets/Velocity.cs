using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Script para el ejercicio "Distancia de frenado de un vehículo"
 * del Tema 2 Cinemática de la partícula" (slide 36)
 */
public class Velocity : MonoBehaviour {

	public Rigidbody rb;
	public Vector3 velocidadInicial = new Vector3(15,0,0);
	public Vector3 aceleracion = new Vector3(-5,0,0);

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = velocidadInicial;
	}

	// Update is called once per frame
	void FixedUpdate () 
	{
		Vector3 velocidadActual = rb.velocity;
		if (Mathf.Abs (velocidadActual.x) < 0.1f) {
			rb.velocity = Vector3.zero;	
		} else {
			velocidadActual = velocidadActual + aceleracion * Time.deltaTime;
			rb.velocity = velocidadActual;
		}
		Debug.Log("<color=red>Tiempo:</color> " + Time.time + " <color=blue>X:</color> " + transform.position.x  + " <color=blue>Velocidad:</color> " + velocidadActual);
	}
}
