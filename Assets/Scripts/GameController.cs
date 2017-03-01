using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public GameObject hazard;
	public Vector3 spawnValues;

	void Start()
	{
		SpawnWaves ();
	}

	//cria um asteróide em posição x aleatória e fora da tela
	void SpawnWaves()
	{
		//define uma posição de acordo com o que foi passado
		Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
		Quaternion spawnRotation = Quaternion.identity; //sem rotação
		Instantiate (hazard, spawnPosition, spawnRotation); //instancia o tiro
	}
}
