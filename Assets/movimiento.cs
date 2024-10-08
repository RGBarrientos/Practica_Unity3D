using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // Start is called before the first frame update
    float horizontalMove;
    float verticalMove;

    float gravity = 9.8f;
    float fallSpeed;

    Vector3 playerInput;

    [SerializeField] 
    CharacterController player;

    Vector3 movePlayer;

    [SerializeField] 
    public float playerSpeed = 5.0f;

    [SerializeField]
    Camera mainCamara;

    Vector3 camForward;
    Vector3 camRight;

    public Animator playerAni;

    void Start()
    {
        player = GetComponent<CharacterController>();
        playerAni = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //FirstMove();
        
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        //Debug.Log(horizontalMove);

        playerInput = new Vector3(horizontalMove,0,verticalMove);
        playerInput = Vector3.ClampMagnitude(playerInput,1);

        camDirection();

        movePlayer = playerInput.x * camRight + playerInput.z * camForward;
        
        player.transform.LookAt(player.transform.position + movePlayer);

        PlayerAnim();

        UseGravity();

        player.Move(movePlayer * playerSpeed * Time.deltaTime);
    }

    void camDirection(){
        camForward = mainCamara.transform.forward;
        camRight = mainCamara.transform.right;

        camForward.y = 0;

        camForward = camForward.normalized;
    }

    void FirstMove(){
        if(Input.GetKey("w")){
            transform.Translate(Vector3.forward * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey("s")){
            transform.Translate(Vector3.back * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey("d")){
            transform.Translate(Vector3.right * playerSpeed * Time.deltaTime);
        }

        if(Input.GetKey("a")){
            transform.Translate(Vector3.left * playerSpeed * Time.deltaTime);
        }
    }

    void PlayerAnim(){
        if(horizontalMove != 0 || verticalMove != 0){ 
            if(Input.GetKey(KeyCode.LeftShift)){
                playerAni.SetBool("Idle", false);
                playerAni.SetBool("Walk", false);
                playerAni.SetBool("Run", true);
                playerSpeed = 10;
            }else{
                playerAni.SetBool("Idle", false);
                playerAni.SetBool("Walk", true);
                playerAni.SetBool("Run", false);
                playerSpeed = 5;
            }
        }else
        {
            playerAni.SetBool("Idle", true);
            playerAni.SetBool("Walk", false);
            playerAni.SetBool("Run", false);
        }
    }

    void UseGravity(){
        if(player.isGrounded){
            fallSpeed = -gravity * Time.deltaTime;
            movePlayer.y = fallSpeed;
        }else{
            fallSpeed -= gravity * Time.deltaTime;
            movePlayer.y = fallSpeed;
        }
        
    }

}