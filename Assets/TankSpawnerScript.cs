using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSpawnerScript : MonoBehaviour {

	public float SpawnerTimer = 0;
	public float TankSpawnTimer = 0;
	public GameObject Tank;
	public int Wave = 0;
	public int BreakTime = 30;
	public List<GameObject> Tanks;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(SpawnerTimer >= TankSpawnTimer)
		{
			GameObject CreatedTank = Instantiate(Tank, new Vector3(Random.Range(-6.28f, 7.6f), 0, Random.Range(-7.44f, 8.14f)), Quaternion.identity, GameObject.Find("Game").transform);
			Tanks.Add(CreatedTank);

			SpawnerTimer = 0;
			TankSpawnTimer = Random.Range(4, 6);
		}
		SpawnerTimer += Time.deltaTime;
	}
}
