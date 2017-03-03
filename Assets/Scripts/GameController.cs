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
	public GUIText scoreText;

	private int score;

	void Start()
	{
		score = 0;
		UpdateScore ();
		//executa uma função em paralelo, sem travar a execução até que ela seja terminada
		StartCoroutine(SpawnWaves ());
	}

	//cria um asteróide em posição x aleatória e fora da tela
	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds (startWait); //espera X segundos para começar

		//loop para ficar sempre executando
		while (true) {
			//para x asteróides
			for (int i = 0; i < hazardCount; i++) {
				//define uma posição de acordo com o que foi passado
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity; //sem rotação
				Instantiate (hazard, spawnPosition, spawnRotation); //instancia o tiro

				//espera x segundos para instanciar outro asteróide
				yield return new WaitForSeconds (spawnWait);
			}

			//espera x segundos até começar outra onda de asteróides
			yield return new WaitForSeconds (waveWait);
		}
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
	}

	//atualiza texto da pontuação
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}
}
