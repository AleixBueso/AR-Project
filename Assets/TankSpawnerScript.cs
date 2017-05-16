using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankSpawnerScript : MonoBehaviour {

	public float SpawnerTimer = 0;
	public float TankSpawnTimer = 0;
	public GameObject Tank;
	public int Wave = 1;
	public int BreakTime = 30;
	public int WaveSpawned = 0;
	public List<GameObject> Tanks;
	public bool InterWave = false;
	public float InterWaveTimer = 0;
	public Text InterWaveText;
	public Text WaveText;
	public Text TanksText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (InterWave)
		{
			InterWaveText.gameObject.SetActive(true);
			WaveText.gameObject.SetActive(false);
			TanksText.gameObject.SetActive(false);

			InterWaveText.text = "Wave " + Wave + " starts in " + (BreakTime - (int)InterWaveTimer);
			if (InterWaveTimer >= BreakTime)
			{
				InterWave = false;
				InterWaveTimer = 0;
			}

			InterWaveTimer += Time.deltaTime;
		}

		else
		{
			InterWaveText.gameObject.SetActive(false);
			WaveText.gameObject.SetActive(true);
			TanksText.gameObject.SetActive(true);

			WaveText.text = "Wave: " + Wave;
			TanksText.text = "Tanks left: " + ((5 * Wave) - WaveSpawned);

			if (SpawnerTimer >= TankSpawnTimer && WaveSpawned < 5 * Wave)
			{
				Vector3 position;
				position = CalculatePosition();
				bool correctPos = false;

				
				while (!correctPos)
				{
					if (position.x <= 40 && position.x >= -40 && position.z <= 40 && position.z >= -40)
						position = CalculatePosition();
					else
						correctPos = true;
				}

				Debug.Log(correctPos + "  " + position);

				GameObject CreatedTank = Instantiate(Tank, Vector3.zero, Quaternion.identity, GameObject.FindGameObjectWithTag("Ground").transform);
				CreatedTank.transform.localPosition = new Vector3(position.x, position.y, position.z);
				Tanks.Add(CreatedTank);
				WaveSpawned++;

				SpawnerTimer = 0;
				TankSpawnTimer = Random.Range(4, 6);
			}

			SpawnerTimer += Time.deltaTime;

			if (WaveSpawned == 5 * Wave && Tanks.Count == 0)
			{
				Wave++;
				InterWave = true;
			}
		}
	}

	public Vector3 CalculatePosition()
	{
		Vector3 newPosition;
		newPosition = new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
		return newPosition;
	}
}
