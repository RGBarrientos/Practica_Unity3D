using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveStaticEnemy : MonoBehaviour
{
    
    [SerializeField]
    float walkSpeed = 3.0f;

    Vector3 initialPosition; //Almacena la posicion inicial
    Vector3 endPosition; //Almacena la posicion final

    [SerializeField]
    int metersOfWalk;

    Vector3 rotation;

    [SerializeField]
    bool leftStart;
    
    // Start is called before the first frame update
    void Start()
    {

        if(leftStart){
            initialPosition = transform.position;
            endPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z + metersOfWalk);
        }else{
            initialPosition = transform.position;
            endPosition = new Vector3(initialPosition.x, initialPosition.y, initialPosition.z - metersOfWalk);
        }
        rotation = transform.eulerAngles;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);
        if(leftStart){
            if(transform.position.z > endPosition.z){
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.localEulerAngles.y + 180, transform.eulerAngles.z);
            }else{
                if(transform.position.z < initialPosition.z){
                    transform.eulerAngles = rotation;
                }
            }
        }else{
            if(transform.position.z < endPosition.z){
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.localEulerAngles.y + 180, transform.eulerAngles.z);
            }else{
                if(transform.position.z > initialPosition.z){
                    transform.eulerAngles = rotation;
                }
            }
        }
        
    }
}
