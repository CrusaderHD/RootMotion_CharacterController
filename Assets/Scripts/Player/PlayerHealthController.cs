using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{

    [Header("Player Health Values")]
    public float playerMaxHealth;
    public float playerCurrentHealth;

    [Header("Text Fields for Slider Text")]
    public Text playerHealthText;

    public Slider playerHealthBar;
    [SerializeField] private Slider playerStaminaBar;
    [SerializeField] private Slider playerManaBar;

    // Start is called before the first frame update
    void Start()
    {
        //playerHealthText = GetComponent<Text>();
        playerMaxHealth = 100f;

        //Reset Player Health to full when loading game.
        playerCurrentHealth = playerMaxHealth;

        //playerHealthBar.value = playerCurrentHealth;
        playerHealthBar.maxValue = playerCurrentHealth;
        playerHealthBar.value = playerHealthBar.maxValue;

    }

    // Update is called once per frame
    void Update()
    {
        //If a key gets pressed, deal damage to player.
        ShowHealthValue();
        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(10);
        }
    }

    //Deals damage to player to show health loss. 
    //TODO: Have player be dealt damage other ways.
    void DealDamage(float damage)
    {
        playerCurrentHealth -= damage;
        playerHealthBar.value = playerCurrentHealth;
        if (playerCurrentHealth <= 0)
        {
            PlayerDie();
        }
    }

    //If players health reaches 0. Player dies. 
    void PlayerDie()
    {
        playerCurrentHealth = 0;
        Debug.Log("Welp, you died.");
    }

    //Shows health value as text format via Slider. 
    void ShowHealthValue()
    {
        string p_HealthValue = playerHealthBar.value.ToString();
        playerHealthText.text = p_HealthValue;
    }
}
