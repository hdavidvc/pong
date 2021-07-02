using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bola : MonoBehaviour
{
        public float velocidad = 30.0f;

        AudioSource fuenteDeAudio;

        public AudioClip audioGol, audioRaqueta, audioRobote, audioInicio, audioFin;

        public int golesIzquierda = 0;
        public int golesDerecha = 0;

        public Text contadorDerecha;
        public Text contadorIzquierda;

        public Text fin ;

        public GameObject again,salir;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;

        fuenteDeAudio = GetComponent<AudioSource>();

        contadorIzquierda.text = golesIzquierda.ToString();
        contadorDerecha.text = golesDerecha.ToString();
        
        fin.text = "";

        again = GameObject.Find ("Button");
        again.SetActive(false);
        salir = GameObject.Find ("Salir");
        salir.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        // velocidad = velocidad + 0.1f;
        
    }

    void OnCollisionEnter2D(Collision2D micolision) {

        if (micolision.gameObject.name == "RaquetaIzquierda") {
            int x = 1;
            int y = direccionY(transform.position, micolision.transform.position);

            Vector2 direccion = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }
        else if (micolision.gameObject.name == "RaquetaDerecha") {
            int x = 1;
            int y = direccionY(transform.position, micolision.transform.position);
            Vector2 direccion = new Vector2(x, y);

            GetComponent<Rigidbody2D>().velocity = direccion * velocidad;

            fuenteDeAudio.clip = audioRaqueta;
            fuenteDeAudio.Play();
        }

        if (micolision.gameObject.name == "Arriba" || micolision.gameObject.name == "Abajo") {
            fuenteDeAudio.clip = audioRobote;
            fuenteDeAudio.Play();
        }
    }
    int direccionY(Vector2 posicionBola, Vector2 posicionRaqueta) {
        if (posicionBola.y > posicionRaqueta.y) {
            return 1;
        }
        else if (posicionBola.y < posicionRaqueta.y) {
            return -1;
        }
        else {
            return 0;
        }

    }

    public void reiniciarBola(string direccion) {
        transform.position = Vector2.zero;
        velocidad = velocidad + 2f;

        if(direccion == "Derecha") {
            golesDerecha++;
            contadorDerecha.text = golesDerecha.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.right * velocidad;
            GameOver("Jugador 2", golesDerecha);

        }
        else if(direccion == "Izquierda") {
            golesIzquierda++;
            contadorIzquierda.text = golesIzquierda.ToString();
            GetComponent<Rigidbody2D>().velocity = Vector2.left * velocidad;
            GameOver("Jugador 1", golesIzquierda);

        }

    }

    public void GameOver(string jugador, int goles) {
        if(goles == 10) {            
            fin.text = "¡¡Ganaste!!\n" + jugador;
            fuenteDeAudio.clip = audioInicio;
            fuenteDeAudio.Play();
            GetComponent<Rigidbody2D>().velocity = Vector2.left * 0;
            again.SetActive(true);
            salir.SetActive(true);
            
        }else {
            fuenteDeAudio.clip = audioGol;
            fuenteDeAudio.Play();            
        }
    }
}
