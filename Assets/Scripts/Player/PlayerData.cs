using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    [Header("Player Movement Attributes.")]
    [Range(1,165)]
    [Tooltip("Player will move forward/back at this speed")] 
    public float playerMovementSpeed;  //Adjusts the forward and backwards movement speed of player. Meters Per Second.

    [Range(1,220)]
    [Tooltip("Player will Rotate at chosen Degrees per second.")]
    public float playerRotationSpeed;  //Adjusts the left and right turning speed of player. Degrees Per Second.

    [Range(100,1000)]
    public float playerJumpForce;      //Applies how much force is applied when player presses jump button.

    [Range(45, 100)]
    public float playerRunSpeed;       //Adjusts the speed of player to a run

    [Range(0, 10)]
    public float playerGravity;        //Adjusts Gravity of player.


    public GameObject player;

}
