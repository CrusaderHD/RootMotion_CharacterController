using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{

    //Player Movement Attributes
    [Header("Player Motor/Data/Interactable")]
    [SerializeField] private PlayerData pData;
    [SerializeField] private CharacterController charController;
    [SerializeField] private Camera camera;
    Vector3 moveDirection = Vector3.zero;
    Animator animator;
    float rotation = 0.0f;
    public bool isPlayerWalking;

    //public AudioSource playerWalking;
    //public AudioSource playerWalkingSource;
    //public AudioClip playerWalkingClip;

    //Vector to move with Mouse.
    private Vector2 mouseDirection;

    //Interactables
    private Interactable interactable;
    private bool interacting;
    public Interactable focus;
    private CharacterCombat playerAttack;
    EnemyStats enemyStats;

    //Attain the RigidBody
    private Rigidbody rb;

    //Create ENUM to change between input type
    public enum InputSetup { WASD, arrowKeys, playstationController, xboxController };
    [Header("Choose the input type.")]
    public InputSetup input = InputSetup.WASD;

    //Access Player Data, Animator and Interactable upon startup.
    void Awake()
    {
        //Add needed components to player.
        if (pData == null)
        {
            pData = gameObject.GetComponent<PlayerData>();
        }

        if (interactable == null)
        {
            interactable = gameObject.GetComponent<Interactable>();
        }
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        charController = GetComponent<CharacterController>();
    }

    //Update control inputs per frame.
    void Update()
    {
        PlayerControls();
    }



    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.UnFocused();
            }
            focus = newFocus;
        }
        newFocus.Focused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.UnFocused();
        }
        focus = null;
    }

    IEnumerator AttackRoutine()
    {
        Debug.Log("Attacking");
        animator.SetBool("isAttacking", true);
        animator.SetInteger("Condition", 2);
        yield return new WaitForSeconds(1);
        animator.SetInteger("Condition", 0);
        animator.SetBool("isAttacking", false);
    }

    void PlayerAttack()
    {
        StartCoroutine(AttackRoutine());
        PlayerAttackAudio();
    }

    void PlayerWalkAudio()
    {
        FindObjectOfType<AudioSource>().loop = true;
        FindObjectOfType<AudioManager>().PlayAudio("PlayerWalk");
    }

    void PlayerIdleAudio()
    {
        FindObjectOfType<AudioSource>().loop = false;
    }

    void PlayerAttackAudio()
    {
        FindObjectOfType<AudioManager>().PlayAudio("PlayerAttack");
    }

    void PlayerControls()
    {
        switch (input)
        {
            case InputSetup.WASD:

                //Move Forward and Turn
                if (Input.GetKey(KeyCode.W))
                {
                    //FindObjectOfType<AudioManager>().loopAudio = true;
                    
                    isPlayerWalking = true;
                    if (Input.GetKeyDown(KeyCode.W))
                    {
                        if (isPlayerWalking)
                        {
                            PlayerWalkAudio();
                        }
                        
                    }
                   
                    if (animator.GetBool("isAttacking") == true)
                    {
                        return;
                    }
                    else if (animator.GetBool("isAttacking") == false)
                    {
                        
                        animator.SetInteger("Condition", 1);
                        moveDirection = new Vector3(0, 0, .3f);
                        moveDirection *= pData.playerMovementSpeed;
                        moveDirection = transform.TransformDirection(moveDirection);
                    }
                    
                }
                if (Input.GetKeyUp(KeyCode.W))
                {
                    isPlayerWalking = false;
                    PlayerIdleAudio();
                    //FindObjectOfType<AudioManager>().loopAudio = false;
                    //FindObjectOfType<AudioSource>().loop = false;
                    //FindObjectOfType<AudioManager>().PlayAudio("PlayerIdle");
                    //animator.SetBool("Running", false);
                    animator.SetInteger("Condition", 0);
                    moveDirection = new Vector3(0, 0, 0);
                }

                rotation += Input.GetAxis("Horizontal") * pData.playerRotationSpeed * Time.deltaTime;
                transform.eulerAngles = new Vector3(0, rotation, 0);
                moveDirection.y -= pData.playerGravity * Time.deltaTime;
                charController.Move(moveDirection * Time.deltaTime);
                



                //Move Backward and Turn
                if (Input.GetKey(KeyCode.S))
                {
                    //animator.SetBool("Running", true);
                    animator.SetInteger("Condition", 1);
                    moveDirection = new Vector3(0, 0, -.3f);
                    moveDirection *= pData.playerMovementSpeed;
                    moveDirection = transform.TransformDirection(moveDirection);
                }

                if (Input.GetKeyUp(KeyCode.S))
                {
                    //animator.SetBool("Running", false);
                    animator.SetInteger("Condition", 0);
                    moveDirection = new Vector3(0, 0, 0);
                }
                moveDirection.y -= pData.playerGravity * Time.deltaTime;
                charController.Move(moveDirection * Time.deltaTime);

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    
                    
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Equipping Weapon.");
                }


                if (Input.GetMouseButtonDown(0))
                {
                    //Create a ray from mouse pointer.
                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    //If the Ray hits a collider.
                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        RemoveFocus();
                    }
                }
                //Focus on interactable object.
                if (Input.GetMouseButtonDown(1))
                {
                    //Create a ray from mouse pointer.
                    Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    //If the Ray hits a collider.
                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        interactable = hit.collider.GetComponent<Interactable>();
                        if (interactable != null)
                        {
                            SetFocus(interactable);
                            interactable.Interact();
                        }
                    }

                    if (animator.GetBool("isRunning") == true)
                    {
                        animator.SetBool("isRunning", false);
                        animator.SetInteger("Condition", 0);
                    }
                    if (animator.GetBool("isRunning") == false)
                    {
                        PlayerAttack();
                    }
                }

                break;
        }

    }

}
