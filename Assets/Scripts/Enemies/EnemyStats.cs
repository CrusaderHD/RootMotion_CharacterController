using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    [Header("Stat Boosters")]
    public int enemyDamage;
    public int enemyArmor;

    [Header("Manage Enemy/AI Stats")]
    public int enemyCurrentHealth;
    public int enemyMaxHealth;



    //Figure damage calculation when working with Armor and Damage modifiers.
        /*
        Figure out the difference between oncoming attack damage and current armor amount on player.
        damage -= enemyArmor.GetValue();
        Just incase the armor amount on the player is > than the oncoming attack. - Prevent healing.
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        Set Current health after taking damage.
        enemyCurrentHealth -= damage;
        */

}
