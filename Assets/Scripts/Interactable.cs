using UnityEngine;

public class Interactable : MonoBehaviour
{

    public float interactionRadius = 3f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }

}
