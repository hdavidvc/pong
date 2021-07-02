using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    AudioSource fuenteDeAudio;
    public AudioClip audioInicio;
    
    // Start is called before the first frame update
    void Start()
    {
        fuenteDeAudio = GetComponent<AudioSource>();   
        fuenteDeAudio.clip = audioInicio;
        fuenteDeAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetMouseButton(1)) {
            SceneManager.LoadScene("SampleScene");
        }
    }
}
