using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	public GameObject explosion;
	public GameObject playerExplosion;

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.name); //exibe no console nome do objeto que destruiu o asteróide

		//se colidir com boundary, abortar script
		if (other.CompareTag ("Boundary"))
			return;

		Instantiate (explosion, transform.position, transform.rotation); //instancia explosão

		//se quem colidiu foi o jogador
		if (other.CompareTag ("Player"))
			Instantiate (playerExplosion, other.transform.position, other.transform.rotation); //instancia explosão do jogador

		//destrói o tiro e o asteróide
		//desde que esteja no mesmo frame, não importa a ordem que o Destroy é utilizado: o objeto não é destruído imediatamente,
		//e sim marcado para ser destruído no final do frame
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
