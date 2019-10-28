using UnityEngine;

public class WeaponDamage : MonoBehaviour
{

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Enemy"))
        {
            Debug.Log("Making Contact with Enemy.");
        }
    }

}
