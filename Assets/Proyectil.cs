using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proyectil : MonoBehaviour {

	/* 
	 * Problema Lanzamiento del portátil Parte II 
	 * Tema 2: Cinemática de la partícula
	 * Slide 74
	 * 
	 */
	public Vector3 initialSpeed = new Vector3(4,4,0);
	private Rigidbody rb;
	private bool shooted;
	private bool collisioned;
	private float shootTime;

	void start() {
		shooted = false;
		collisioned = false;
	}

	void FixedUpdate () {
		rb = GetComponent<Rigidbody>();

		if (Input.GetKeyDown ("space") && !shooted) {
			shootTime = Time.realtimeSinceStartup;
			shooted = true;
			rb.velocity = initialSpeed;
		}

		if ((Mathf.Abs(rb.velocity.y) < 0.1f) && shooted && !collisioned) {
			float timeElapsed = (Time.realtimeSinceStartup - shootTime);
			Debug.Log ("Vy es 0 a los " + timeElapsed + " segundos, alcanzando una altura y = " + this.transform.position.y +  " metros.");	
		}

		Debug.DrawRay (transform.position, rb.velocity, Color.yellow);

	}

	void OnCollisionEnter(Collision collision) {
		if (!collisioned && shooted) {
			collisioned = true;
			float timeElapsed = (Time.realtimeSinceStartup - shootTime);
			Debug.Log ("Distancia recorrida: " + collision.contacts [0].point.x + " en " + timeElapsed + " segundos");
			Debug.DrawRay (collision.contacts [0].point, collision.contacts [0].normal, Color.red,10);
		}
	}
}
