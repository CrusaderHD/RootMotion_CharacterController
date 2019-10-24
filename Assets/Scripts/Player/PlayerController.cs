using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator), (typeof(Camera)))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Animator movementAnimator;
    [SerializeField] private Camera camera;

    [Header("Player Motor/Data/Interactable")]
    [SerializeField] private PlayerMotor pMotor;
    [SerializeField] private PlayerData pData;
    private Interactable interactable;

    [Header("Attributes of the Cube")]
    //[SerializeField] private Material material;
    //[SerializeField] private Renderer renderer;

    private bool interacting;
    private bool isJumping;
    private bool isGrounded;

    public Interactable focus;
    private Rigidbody rb;

    //Create ENUM to change between input type
    public enum InputSetup { WASD, arrowKeys, playstationController, xboxController };
    [Header("Chose the input type.")]
    public InputSetup input = InputSetup.WASD;

    //Access Player Motor, Data, Animator and Interactable upon startup.
    void Awake()
    {
        if (pData == null)
        {
            pData = gameObject.GetComponent<PlayerData>();
        }

        if (pMotor == null)
        {
            pMotor = gameObject.GetComponent<PlayerMotor>();
        }

        if (movementAnimator == null)
        {
            movementAnimator = gameObject.GetComponent<Animator>();
        }

        if (interactable == null)
        {
            interactable = gameObject.GetComponent<Interactable>();

        }

        //Access Render component of Cube for interaction.
        //renderer = GameObject.FindGameObjectWithTag("Cube").GetComponent<Renderer>();
        //renderer.enabled = true;
        //Access Rigidbody component.
        rb = GetComponent<Rigidbody>();
    }

    //Update control inputs per frame.
    void Update()
    {
        PlayerControls();
    }

    //void GroundCheck()
    //{
    //    RaycastHit hit;
    //    float distance = 1.1f;
    //    Vector3 direction = new Vector3(0, -1);

    //    if (Physics.Raycast(transform.position, direction, out hit, distance))
    //    {
    //        isGrounded = true;
    //    }
    //    else
    //    {
    //        isGrounded = false;
    //    }

    //}

    public static IEnumerator StopJumping(PlayerController pc, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        pc.isJumping = false;
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


    void PlayerControls()
    {
        switch (input)
        {
            case InputSetup.WASD:

                if (Input.GetKey(KeyCode.Space))
                {
                    isJumping = true;
                    movementAnimator.Play("Jumping");
                    StartCoroutine(StopJumping(this, 1.883f));
                }

                else if (Input.GetKey(KeyCode.W))
                {
                    pMotor.MovePlayer(pData.playerMovementSpeed);
                    if (!isJumping)
                    {
                        movementAnimator.SetBool("isWalking", true);
                        movementAnimator.Play("Walking");
                    }
                }
                else
                {
                    movementAnimator.SetBool("isWalking", false);
                }

                if (Input.GetKey(KeyCode.S))
                {
                    pMotor.MovePlayer(-pData.playerMovementSpeed);
                    movementAnimator.Play("Walking");
                    movementAnimator.SetBool("isWalking", true);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    pMotor.RotatePlayer(pData.playerRotationSpeed);
                }
                if (Input.GetKey(KeyCode.A))
                {
                    pMotor.RotatePlayer(-pData.playerRotationSpeed);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Equipping Weapon.");
                    movementAnimator.SetBool("isEquipping", true);
                    movementAnimator.Play("Unarmed Equip Over Shoulder");
                }

                if (Input.GetKeyDown(KeyCode.Alpha1))
                {
                    Debug.Log("Attacking");
                    movementAnimator.SetBool("isAttacking", true);
                    movementAnimator.Play("Stable Sword Outward Slash" +
                                          "");
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
                }

                break;
        }

        switch (input)
        {
            case InputSetup.arrowKeys:

                if (Input.GetKey(KeyCode.UpArrow))
                {
                    pMotor.MovePlayer(pData.playerMovementSpeed);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    pMotor.MovePlayer(-pData.playerMovementSpeed);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    pMotor.RotatePlayer(pData.playerRotationSpeed);
                }
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    pMotor.RotatePlayer(-pData.playerRotationSpeed);
                }
                break;
        }
    }

}
