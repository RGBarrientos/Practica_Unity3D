using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class PlayerLife : MonoBehaviour
{
    
    [SerializeField]
    float life = 100.0f;

    [SerializeField]
    float damage = 10.0f;

    float actualyLife;
    
    [SerializeField]
    Image lifeImage;

    [SerializeField]
    GameObject message;

    [SerializeField]
    TMP_Text messageText;

    public bool getDamage = true;

    // Start is called before the first frame update
    void Start()
    {
        actualyLife = life;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PlayerHealth(){
        if(getDamage){
            if(actualyLife > 0){
                actualyLife -= life * 0.1f;
                float percentegeLife = actualyLife / life;
                lifeImage.fillAmount = percentegeLife;
            }else
            {
                Debug.Log("GAME OVER");
                messageText.text = "GAME OVER";
                message.SetActive(true);
                StartCoroutine("TimeToMessage");
                
            }
        }
        
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.Equals("Enemy")){
            if(getDamage){
                PlayerHealth();
            }else{
                Destroy(other.gameObject); 
            }
            
        }
    }

    IEnumerator TimeToMessage(){
        yield return new WaitForSeconds(3);
        message.SetActive(false);
        messageText.text = "";
        SceneManager.LoadScene("Menu");
    }
}
