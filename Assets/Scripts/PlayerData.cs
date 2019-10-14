using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerData : MonoBehaviour
{
    [Range(25,65)]
    public float playerMovementSpeed;  //Adjusts the forward and backwards movement speed of player. Meters Per Second.

    [Range(45, 100)]
    public float playerRunSpeed;       //Adjusts the speed of player to a run.

    [Range(70,220)]
    public float playerRotationSpeed;  //Adjusts the left and right turning speed of player. Degrees Per Second.

    [Range(100,1000)]
    public float playerJumpForce;      //Applies how much force is applied when player presses jump button.

    public GameObject player;

}
