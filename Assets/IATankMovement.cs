using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IATankMovement : MonoBehaviour {

	public float speed;
	public Transform target;
    public GameObject Ground;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		target = GameObject.FindGameObjectWithTag("Tower").transform;
		Ground = GameObject.FindGameObjectWithTag("Ground");
	}
	
	// Update is called once per frame
	void Update () {

		Physics.gravity = - Ground.transform.up;

		//gameObject.transform.localRotation = Vector3.RotateTowards(transform.forward, target.position, 1000, 1000);

		gameObject.transform.up = Ground.transform.up;

		if (Vector3.Distance(gameObject.transform.localPosition, target.localPosition) > 10)
		{
			float step = speed * Time.deltaTime;
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.localPosition, step);
		}

		//transform.localPosition = new Vector3(transform.localRotation.x, 0, transform.localPosition.z);
		Debug.Log(transform.localPosition);
	}
}
