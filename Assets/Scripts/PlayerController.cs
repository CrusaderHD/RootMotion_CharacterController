using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator movementAnimator;

    public bool isGrounded;

    private Rigidbody rb;

    public PlayerMotor pMotor;
    public PlayerData pData;

    //Create ENUM to change between input type.
    public enum InputSetup { WASD, arrowKeys, playstationController, xboxController };
    public InputSetup input = InputSetup.WASD;

    //Access Player Motor and Data upon startup.
    void Start()
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


        rb = GetComponent<Rigidbody>();
    }

    //Update control inputs per frame.
    void Update()
    {
        //Player Control Inputs.
        PlayerControls();
        GroundCheck();


    }

    void GroundCheck()
    {
        RaycastHit hit;
        float distance = 1.1f;
        Vector3 direction = new Vector3(0, -1);

        if (Physics.Raycast(transform.position, direction, out hit, distance))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }

    }



    void PlayerControls()
    {
        switch (input)
        {
            case InputSetup.WASD:

                if (Input.GetKey(KeyCode.W) && isGrounded)
                {
                    movementAnimator.SetBool("isWalking", true);
                    pMotor.MovePlayer(pData.playerMovementSpeed);
                    movementAnimator.Play("Walking");
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

                if (Input.GetKey(KeyCode.Space))
                {
                    isGrounded = false;
                    movementAnimator.Play("Jumping");
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
