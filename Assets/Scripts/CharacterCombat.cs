using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    [Range(1, 10)]
    public float attackSpeed;

    private float attackCooldown = 0f;

    PlayerStats myStats;

    void Start()
    {
        myStats = GetComponent<PlayerStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public virtual void Attack(PlayerStats targetStats)
    {
        if (attackCooldown <= 0f)
        {

            attackCooldown = 1f / attackSpeed;
        }

    }
}