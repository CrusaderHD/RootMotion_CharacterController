using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthController : MonoBehaviour
{

    public float playerMaxHealth;
    public float playerCurrentHealth;
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
        ShowHealthValue();
        if (Input.GetKeyDown(KeyCode.X))
        {
            DealDamage(10);
        }
    }

    void DealDamage(float damage)
    {
        playerCurrentHealth -= damage;
        playerHealthBar.value = playerCurrentHealth;
        if (playerCurrentHealth <= 0)
        {
            PlayerDie();
        }
    }

    //Calculate Health
    //float CalculateHealth()
    //{
        //return playerCurrentHealth / playerMaxHealth;
    //}

    void PlayerDie()
    {
        playerCurrentHealth = 0;
        Debug.Log("Welp, you died.");
    }

    void ShowHealthValue()
    {
        string p_HealthValue = playerHealthBar.value.ToString();
        playerHealthText.text = p_HealthValue;
    }
}
