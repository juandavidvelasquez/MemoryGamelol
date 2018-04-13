using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;// se usa las librerias de la interface de unity para crear los botones y control del juego

public class ControladorJuego : MonoBehaviour 
{
	[SerializeField]
	private Sprite imagenVolteada;// se crea una variable par hacer referencia a la sprite que se usara


	public Sprite[] imagensitas;

	public List<Sprite> imagenesJuego = new List<Sprite> ();

	public List<Button> botones = new List<Button>();// se crea una lista publica especifica para los elementos u objetos

	public bool adivinaImagen1,adivinaImagen2;// se crea un bool porque necesita una variable de tipo falso y verdadero 

	private int contadorAdivinanzas;// se crea un contador de tipo entero que cuente las veces que adivina 
	private int contadorCorregidas;
	private int JuegoAdivinanzas;

	private int adivinaImagenindex1,adivinaImagenindex2;

    public Sprite reverso;

	[SerializeField] private string imagen1,imagen2;



	public Text gameOver;



	void Awake()
	{
		imagensitas = Resources.LoadAll<Sprite> ("Sprites"); //se crea una carga de recursos
	}

	void Start()
	{
		
        Shuffle(imagenesJuego);
        GetButtons();
		AddListeners ();
		AddGamePuzzles ();
		JuegoAdivinanzas = imagenesJuego.Count/2;// en el start se llama los metodos para que se ejecuten una sola vez mientras va leyendo la script
	   
	}
			
	void GetButtons () // se crea un void para que se agreguen los botones 
	{
		GameObject[] objects = GameObject.FindGameObjectsWithTag("Boton"); // se crea una arrayslist para los objetos y se le da una referencia para buscar por medio del nombre del objeto

		for (int i = 0;i < objects.Length; i++){ // se inicia un contador de enteros para los objetos con su 
			botones.Add(objects[i].GetComponent<Button>());// se establece el componente de boton al mismo que se esta creando
			botones [i].image.sprite = imagenVolteada;// se crea un indice de imagenes tipo sprite para la imagen de fondo de cada boton antes de voltearse
	}
}
	void AddGamePuzzles()
	{
		int looper = botones.Count;// 
		int index = 0;

		for (int i = 0; i < looper; i++){
			if (index == looper / 2) {
				index = 0;
			}
			imagenesJuego.Add (imagensitas [index]);

			index++;// se crea un indice en un for para reproducir el loop de cada imagen divida por 2 
		}
	}
	void AddListeners()
	{
		foreach (Button boton in botones)
        {
			boton.onClick.AddListener (() => PickAPuzzle());
		}
	}

	 public void PickAPuzzle()
	 {
		Debug.Log ("Detecta El Boton" + name);

		if (!adivinaImagen1)
        {
			
			adivinaImagen1 = true;

			adivinaImagenindex1 = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);// hace un analizis al indice buscando el nombre del objeto 
		
			imagen1 = imagenesJuego [adivinaImagenindex1].name;

			botones [adivinaImagenindex1].image.sprite = imagenesJuego [adivinaImagenindex1];

		}
        else if (!adivinaImagen2)
        {

			adivinaImagen2 = true;

			adivinaImagenindex2 = int.Parse (UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);// hace un analizis al indice buscando el nombre del objeto 

			imagen2 = imagenesJuego [adivinaImagenindex2].name;

			botones [adivinaImagenindex2].image.sprite = imagenesJuego [adivinaImagenindex2];
            VerificarParejas();

        }
	 }

    public void VerificarParejas()
    {
        if (imagen1 == imagen2)
        {
            Debug.Log("Son Compatibles");
            GameObject[] ficha = GameObject.FindGameObjectsWithTag ("Boton");
            for (int i = 0; i < ficha.Length; i++)
            {
                if(ficha[i].GetComponent<Image>().sprite != imagenVolteada)
                {
                    Destroy(ficha[i]) ;
                    imagen1 = null;
                    imagen2 = null;
                    adivinaImagen1 = false;
                    adivinaImagen2 = false;
                }
            }
 
        }
        else
        {
            Debug.Log("No Son Compatibles");

            contadorAdivinanzas++;

            StartCoroutine(Check());  // se inicializa la corrutina 
        }
    }
		IEnumerator Check()
		{
			yield return new WaitForSeconds(1f);

		    if (imagen1 == imagen2)
            { 
    
			    yield return new WaitForSeconds (.5f);

			    botones [adivinaImagenindex1].interactable = false;
			    botones [adivinaImagenindex2].interactable = false;

			    CheckIfTheGameIsFinish ();

		    }
            else
            {

			    yield return new WaitForSeconds (.5f);
					
			    botones [adivinaImagenindex1].image.sprite = imagenVolteada;
			    botones [adivinaImagenindex2].image.sprite = imagenVolteada;

		    }
				yield return new WaitForSeconds (.5f);

		adivinaImagen1 = adivinaImagen2 = false;

	}


    void CheckIfTheGameIsFinish()
    {
			contadorCorregidas++;

		if (contadorCorregidas == JuegoAdivinanzas)
        {
			Debug.Log ("Juego terminado ");
			 
			Debug.Log("if took you" + JuegoAdivinanzas + "faltan parejas para finalizar");

			gameOver.text = "Game Over ";
		}
	}

	 
	void Shuffle (List<Sprite>list)
	{
		for (int i = 0; i < list.Count; i++)
        {
			Sprite temp = list [i];
			int randomIndex = Random.Range(0, list.Count);
			list [i] = list [randomIndex];
			list [randomIndex] = temp;// se crea un indice aleatorio temporal 
		}
	}
}
		






//controlador del juego 
