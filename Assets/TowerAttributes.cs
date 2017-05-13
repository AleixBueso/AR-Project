using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerAttributes : MonoBehaviour {

	public int HitPoints = 100;
	public int MaxHitPoints = 100;
	public Slider HPBar;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HPBar.value = HitPoints;
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Shell")
			HitPoints -= 10;
	}
}
