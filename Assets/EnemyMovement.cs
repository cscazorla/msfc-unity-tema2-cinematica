using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public GameObject player;
	public float moveSpeed = 1f;

	private Vector3 vectorDesplazamiento;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		vectorDesplazamiento = player.transform.position - transform.position;
		transform.position += vectorDesplazamiento.normalized * moveSpeed * Time.deltaTime;

		Debug.DrawRay (transform.position, vectorDesplazamiento.normalized, Color.green);
		Debug.Log ("<color=red>Jugador:</color>" + player.transform.position + " <color=blue>Enemigo:</color> " + transform.position + "Vector desplazamiento: " + vectorDesplazamiento);
	}
}
