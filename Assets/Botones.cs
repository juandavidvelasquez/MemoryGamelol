using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botones : MonoBehaviour // la script es para usar los botones del canvas y panel creados 
{
	[SerializeField]
	private Transform imagens; // un transform (donde se tiene rotacion y posicion del objeto del juego que lleva la imagen)porque es un elemento de tipo UI 

	[SerializeField]
	private GameObject boton; // se define un objeto de juego para el boton que sera clickeado en el juego 

	void Awake()// se inicia en awake y no en start
	{
		for (int i = 0; i < 32; i++) // se crea un for "para"  un valor de entero que indique que es menor a 32
		{
			GameObject booton = Instantiate(boton); // se crea una instancia o copia del boton
			booton.name = "" + i; // es muy importante esta parte de la script pra que reconozca el nombre o referencia 
			booton.transform.SetParent (imagens,false); // se establece un bool para figar ubna posicion global y que no se ubiquen al instanciarse en una fila recta
        }
	}
}
// agregar botones
