using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{

    public float playerMaxHealth { get; set; }  
    public float playerCurrentHealth { get; set; }

    [SerializeField] private Slider playerHealthBar;
    [SerializeField] private Slider playerStaminaBar;
    [SerializeField] private Slider playerManaBar;

    // Start is called before the first frame update
    void Start()
    {
        playerMaxHealth = 100f;
        //Reset Player Health to full when loading game.
        playerCurrentHealth = playerMaxHealth;
        playerHealthBar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(10);
        }
    }

    void DealDamage(float damage)
    {
        playerCurrentHealth -= damage;
        playerHealthBar.value = CalculateHealth();
        if (playerCurrentHealth <= 0)
        {
            PlayerDie();
        }
    }

    //Calculate Health
    float CalculateHealth()
    {
        return playerCurrentHealth / playerMaxHealth;
    }

    void PlayerDie()
    {
        playerCurrentHealth = 0;
        Debug.Log("Welp, you died.");
    }

}
