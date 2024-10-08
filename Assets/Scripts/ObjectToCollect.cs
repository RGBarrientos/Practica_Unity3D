using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectToCollect : MonoBehaviour
{

    int coins = 0;

    [SerializeField]
    TMP_Text textCoin; 

    [SerializeField]
    int totalCoins;

    [SerializeField]
    GameObject message;

    [SerializeField]
    TMP_Text messageText;

    //Scale
    Vector3 scale;

    [SerializeField]
    int x = 1, y = 1, z = 1;

    PlayerLife life;

    // Start is called before the first frame update
    void Start()
    {
        scale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        life = GetComponent<PlayerLife>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("q")){
            if(coins >= totalCoins){
                transform.localScale = new Vector3(x,y,z);
                Debug.Log("Poder activable");
                life.getDamage = false;
                StartCoroutine("TimeToGrowUp");
                coins -= totalCoins;
                textCoin.text = coins.ToString();
            }else{
                Debug.Log("Necesitas más");
                messageText.text = "Necesitas más";
                message.SetActive(true);
                StartCoroutine("TimeToMessage");
            }
        }
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Coin")){
            coins += 1;
            textCoin.text = coins.ToString();
            Destroy(other.gameObject);           
        }
    }

    IEnumerator TimeToGrowUp(){
        yield return new WaitForSeconds(5);
        transform.localScale = scale;
        life.getDamage = true;
    }

    IEnumerator TimeToMessage(){
        yield return new WaitForSeconds(2);
        message.SetActive(false);
        messageText.text = "";
    }
}
