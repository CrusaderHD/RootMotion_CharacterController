using UnityEngine;

public class AnimatorController : MonoBehaviour
{

    public Animator animator;
    public bool isAttacking;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Attacking");
            isAttacking = true;
            animator.Play("katanaSlash");
        }

    }
}
