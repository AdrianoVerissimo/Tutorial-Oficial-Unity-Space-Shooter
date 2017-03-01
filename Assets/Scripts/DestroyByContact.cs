using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		//Debug.Log (other.name); //exibe no console nome do objeto que destruiu o asteróide

		//se colidir com boundary, abortar script
		if (other.CompareTag ("Boundary"))
			return;
		
		//destrói o tiro e o asteróide
		//desde que esteja no mesmo frame, não importa a ordem que o Destroy é utilizado: o objeto não é destruído imediatamente,
		//e sim marcado para ser destruído no final do frame
		Destroy (other.gameObject);
		Destroy (gameObject);
	}
}
