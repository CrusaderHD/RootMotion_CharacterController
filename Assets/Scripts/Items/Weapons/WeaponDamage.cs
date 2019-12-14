using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    //Trigger showing the Weapon has made contact with enemy.
    //TODO: Give weapon Damage multiplyer and stats. 
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Debug.Log("Making Contact with Enemy.");
        }
    }

}
