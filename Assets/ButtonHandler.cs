using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonHandler : MonoBehaviour
{
    public void GameOver() {
        SceneManager.LoadScene("SampleScene");    
    }
    public void exit() {
        Application.Quit();
    }
}
