using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{

    [SerializeField]
    GameObject panelEsc;

    [SerializeField]
    GameObject panelMes;

    bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        panelEsc.SetActive(false);
        panelMes.SetActive(false);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)){
            active = !active;
            if(active){
                panelEsc.SetActive(true);
            }else{
                panelEsc.SetActive(false);
            }
        }    
    }

    public void Continue() {
        panelEsc.SetActive(false);
        active = !active;
    }

    public void Exit(){
        SceneManager.LoadScene("Menu");
    }
}
