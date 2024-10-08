using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    GameObject target;

    NavMeshAgent agent;

    int pointPatroll;

    [SerializeField]
    GameObject[] patrollZones;

    [SerializeField]
    float persecutionRange;

    [SerializeField]
    float attackRange;

    bool persecution = false;

    bool rangePersecution;

    bool rangeOfAttack;

    [SerializeField]
    LayerMask isLayer;

    Animator enemyAnim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        pointPatroll = Random.Range(0,patrollZones.Length);
        //Debug.Log(pointPatroll);
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!persecution){
            //enemyAnim.SetBool("Walk",true);
            //enemyAnim.SetBool("Run",false);
            agent.SetDestination(patrollZones[pointPatroll].transform.position);
        }else{
            //enemyAnim.SetBool("Walk",false);
            //enemyAnim.SetBool("Run",true);
            agent.SetDestination(target.transform.position);
        }
        Persecution();
        
        
    }

    void OnTriggerEnter(Collider Other){
        if(Other.gameObject.tag.Equals("Patrol")){
            int point = Random.Range(0,patrollZones.Length);
            while(true){
                if(point == pointPatroll){
                    point = Random.Range(0,patrollZones.Length);
                    Debug.Log(pointPatroll);
                }else{
                    pointPatroll = point;
                    Debug.Log(pointPatroll);
                    return;
                }
            }
            
        }
    }

    private void OnDrawGizmos(){
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y,
        transform.position.z), persecutionRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(new Vector3(transform.position.x, transform.position.y,
        transform.position.z), attackRange);
    }

    void Persecution(){
        rangePersecution = Physics.CheckCapsule(transform.position,
        transform.position,persecutionRange,isLayer);

        rangeOfAttack = Physics.CheckCapsule(transform.position,
        transform.position,attackRange,isLayer);

        if(rangePersecution){
            persecution = true;
            agent.speed = 8.5f;
            agent.stoppingDistance = 5;
            enemyAnim.SetBool("Walk", true);
            if(rangeOfAttack){
                transform.LookAt(target.transform);
                enemyAnim.SetBool("Attack", true);
                enemyAnim.SetBool("Walk", false);
            }
        }else{
            persecution = false;
            agent.speed = 5;
            agent.stoppingDistance = 0;
            enemyAnim.SetBool("Attack", false);
            enemyAnim.SetBool("Walk", true);
        }
    }
}
