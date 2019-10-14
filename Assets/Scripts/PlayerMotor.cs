using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    public CharacterController characterController;  //Holds the character controller component.
    public Transform tf;                             //Holds the transform location of character.
    public PlayerData playerData;                    //Finds the player data.


    //Find and assign all variables needed.
    void Start()
    {
        if (playerData == null)
        {
            playerData = gameObject.GetComponent<PlayerData>();
        }

        if (tf == null)
        {
            tf = gameObject.GetComponent<Transform>();
        }

        if (characterController == null)
        {
            characterController = gameObject.GetComponent<CharacterController>();
        }
    }

    //Create a simple forward and backwards movement function for player model.
    public void MovePlayer(float speed)
    {
        //Create a vector to hold data.
        Vector3 p_MovementSpeed;
        //Ensure vector is facing same direction as player - On the Z-Axis.
        p_MovementSpeed = transform.forward;
        p_MovementSpeed *= speed;
        //Call Simple Move function.
        characterController.SimpleMove(p_MovementSpeed);
    }

    //Create a simple rotation function to turn player left and right.
    public void RotatePlayer(float speed)
    {
        Vector3 p_RotationSpeed;
        //Rotate vector 1 degree per frame draw.
        p_RotationSpeed = Vector3.up;
        //Adjust the rotation based on the float "speed"
        p_RotationSpeed *= speed;
        //Alter the rotation from per frame to per second.
        p_RotationSpeed *= Time.deltaTime;
        //Rotate Player Model in Local Space.
        transform.Rotate(p_RotationSpeed, Space.Self);
    }


}
