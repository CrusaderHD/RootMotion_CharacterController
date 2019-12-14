using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Death Effect Manager")]
    public ParticleSystem deathEffect;
    public Transform deathEffectTransform;

    [Header("Look Radius")]
    [Range(1, 20)]
    public float lookRadius;

    [Header("Target and Movement Manager")]
    public Transform target;  //Target Transform reference
    NavMeshAgent agent;

    [Header("Stat Manager")]
    public int enemyDamage;
    public int enemyArmor;
    public int enemyCurrentHealth;
    public int enemyMaxHealth;

    [Header("Animation Handler")]
    Animator enemyAnimator;

    [Header("Slider Handler")]
    [SerializeField] private Slider enemyHealthBar;

    [Header("Collider/Trigger Manager")]
    public bool hasCollided;

    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentHealth = enemyMaxHealth;
        enemyHealthBar.maxValue = enemyMaxHealth;
        enemyHealthBar.value = enemyHealthBar.maxValue;
        agent = GetComponent<NavMeshAgent>();
        enemyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCollided)
        {
            Debug.Log("Enemy Taking Damage from Player");
            enemyCurrentHealth -= 5;
        }
        TargetPlayer();
        UpdateHealthSlider();
        KillEnemy();
    }

    public void DeathEffect()
    {
        Instantiate(deathEffect, deathEffectTransform.position, Quaternion.identity);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "PlayerWeapon")
        {
            hasCollided = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        hasCollided = false;
    }

    void UpdateHealthSlider()
    {
        enemyHealthBar.value = enemyCurrentHealth;
    }

    IEnumerator EnemyAttackRoutine()
    {
        Debug.Log("Attacking");
        enemyAnimator.SetBool("isAttacking", true);
        enemyAnimator.SetInteger("Condition", 2);
        yield return new WaitForSeconds(1);
        enemyAnimator.SetInteger("Condition", 0);
        enemyAnimator.SetBool("isAttacking", false);
    }

    void EnemyAttack()
    {
        StartCoroutine(EnemyAttackRoutine());
    }

    void KillEnemy()
    {
        if (enemyCurrentHealth <= 0)
        {
            DeathEffect();
            Debug.Log("Enemy has died");
            Destroy(gameObject);
        }
    }

    //TargetPlayer
    void TargetPlayer()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            enemyAnimator.SetInteger("Condition", 1);

            //Continue Rotation towards target - Also, if within Attacking Distance
            if (distance <= agent.stoppingDistance)
            {
                //Trigger Idle
                enemyAnimator.SetInteger("Condition", 0);
                //Attack Target
                PlayerManager targetStats = target.GetComponent<PlayerManager>();
                if (targetStats != null)
                {
                    if (targetStats.playerCurrentHealth > 0)
                    {
                        EnemyAttack();
                    }
                }
                //Face Target
                FaceTarget();
            }
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
