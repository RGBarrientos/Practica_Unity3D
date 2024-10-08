using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void ButtonPlay(){
        SceneManager.LoadScene("SampleScene");
    }

    public void AboutButton(){

    }

    public void ExitButton(){
        Application.Quit();
    }
}
