using UnityEngine;
using UnityEngine.UI;
public class PowerupPickup : MonoBehaviour
{

    public GameObject pickupEffect;
    public float multiplyer = 1.4f;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Pickup(collider);
        }
    }


    void Pickup(Collider playerCollider)
    {
        //Spawn a cool effect.
        Instantiate(pickupEffect, transform.position, transform.rotation);

        //Apply Effect to Player.
        HealthPowerUpIncrease(playerCollider);


        //Remove Powerup from scene. 
        Destroy(gameObject);
    }

    void HealthPowerUpIncrease(Collider playerCollider)
    {
        PlayerHealthController healthController = playerCollider.GetComponent<PlayerHealthController>();
        healthController.playerMaxHealth *= multiplyer;
        healthController.playerCurrentHealth = healthController.playerMaxHealth;
        healthController.playerHealthBar.maxValue = healthController.playerCurrentHealth;
        healthController.playerHealthBar.value = healthController.playerHealthBar.maxValue;
    }

}
