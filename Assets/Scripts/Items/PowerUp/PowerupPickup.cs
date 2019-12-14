using UnityEngine;
using UnityEngine.UI;
public class PowerupPickup : MonoBehaviour
{

    public GameObject pickupEffect; //Particle Effect to Trigger when Powerup is picked up.

    [Range(0,10)]
    [SerializeField] private int effectMultiplyer = 2; //Multiplyer for Powerup effect. 

    //If player enters trigger for Power ups. Pick it up.
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Pickup(collider);
        }
    }


    void Pickup(Collider playerCollider)
    {
        //Cool Particle effect on Powerup Pickup.
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply Effect to Player.
        HealthPowerUpIncrease(playerCollider);
        
        //Remove Powerup from scene. 
        Destroy(gameObject);
    }

    //Effects of Max Health increase power up.
    void HealthPowerUpIncrease(Collider playerCollider)
    {
        PlayerManager healthController = playerCollider.GetComponent<PlayerManager>();
        healthController.playerMaxHealth *= effectMultiplyer;
        healthController.playerCurrentHealth = healthController.playerMaxHealth;
        healthController.playerHealthBar.maxValue = healthController.playerCurrentHealth;
        healthController.playerHealthBar.value = healthController.playerHealthBar.maxValue;
    }

}
