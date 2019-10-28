using System.Security.Cryptography;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Weapon"))
        {
            Destroy(this.gameObject);
        }
    }
}
