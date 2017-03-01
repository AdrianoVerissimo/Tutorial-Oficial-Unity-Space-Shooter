using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;
	public int hazardCount = 1;
	public float spawnWait;
	public float startWait;
	public float waveWait;

	void Start()
	{
		StartCoroutine(SpawnWaves ());
	}

	//cria um asteróide em posição x aleatória e fora da tela
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait);
		while (true) {
			for (int i = 0; i < hazardCount; i++) {
				//define uma posição de acordo com o que foi passado
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity; //sem rotação
				Instantiate (hazard, spawnPosition, spawnRotation); //instancia o tiro

				//coroutine
				yield return new WaitForSeconds (spawnWait);
			}
			yield return new WaitForSeconds (waveWait);
		}
	}
}
