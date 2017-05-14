using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IATankMovement : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		target = GameObject.FindGameObjectWithTag("Tower").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(gameObject.transform.position, target.position) > 2)
			agent.SetDestination(target.position);
	}
}
