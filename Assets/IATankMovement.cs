using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IATankMovement : MonoBehaviour {

	public Transform target;
	NavMeshAgent agent;
	public float speed = 10f;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		target = GameObject.FindGameObjectWithTag("Tower").transform;
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion targetRotation = Quaternion.LookRotation(target.position - transform.position);
		transform.rotation.Set(- targetRotation.x, - targetRotation.y, - targetRotation.z, - targetRotation.w);


		if (Vector3.Distance(gameObject.transform.position, target.position) > 2)
		{
			float step = speed * Time.deltaTime;
			transform.localPosition = Vector3.MoveTowards(transform.localPosition, target.localPosition, step);
		}
	}
}
