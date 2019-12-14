using UnityEngine;

public class Interactable : MonoBehaviour
{

    private bool isFocused = false;
    private Transform player;
    public Transform interactionTransform;
    public float interactionRadius = 3f;

    public virtual void Interact()
    {
        //This method is meant to be overridden.
        //Debug.Log("Interacting with: " + transform.name);
    }

    void Update()
    {
        
        if (isFocused)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= interactionRadius)
            {
                Interact();
                //Debug.Log("Interacting.");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
        {
            interactionTransform = transform;
        }

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(interactionTransform.position, interactionRadius);
    }

    public void Focused(Transform playerTransform)
    {
        isFocused = true;
        player = playerTransform;
    }

    public void UnFocused()
    {
        isFocused = false;
        player = null;
    }

}
