using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject playerPrefab;
    EnemyController enemyController;

    [Header("Fields for Slider Text")]
    public Text playerHealthText;
    public Slider playerHealthBar;
    public Slider playerStaminaBar;
    public Slider playerManaBar;

    [Header("Manage Player Lives")]
    public Image heartOne;
    public Image heartTwo;
    public Image heartThree;
    public static int heartCounter;
    private int numberOfHearts = 3;

    [Header("Manage Game Over")]
    public GameObject gameOverUI;

    [Header("Stat Boosters")]
    public int playerDamage;
    public int playerArmor;

    [Header("Manage Player Stats")]
    public int playerCurrentHealth;
    public int playerMaxHealth;

    [Header("Collsion Checker")]
    public bool hasCollided;
    

    #region Singleton

    public static PlayerManager instance;
    void Awake()
    {
        instance = this;
    }

    #endregion

    void Start()
    {
        //EquipmentManager.instance.onEquipmentChanged += OnEquipmentChanged;  //Track Damage and Armor modifiers from equipment
        playerCurrentHealth = playerMaxHealth;
        enemyController = GetComponent<EnemyController>();
        playerHealthBar.maxValue = playerMaxHealth;
        playerHealthBar.value = playerHealthBar.maxValue;
        //PlayerSpawn();
        if (numberOfHearts != 3)
        {
            numberOfHearts = 3;
        }
    }

    private void Update()
    {
        if (hasCollided)
        {
            Debug.Log("Take Damage from Player Manager");
            playerCurrentHealth -= 1;
        }
        LifeTracker();
        ShowHealthValue();
        KillPlayer();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "EnemyWeapon")
        {
            hasCollided = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        hasCollided = false;
    }

    //Shows health value as text format via Slider.
    void ShowHealthValue()
    {
        string p_HealthValue = playerHealthBar.value.ToString();
        playerHealthBar.value = playerCurrentHealth;
        playerHealthText.text = p_HealthValue;
    }

    //Track number of Lives/Hearts player has.
    public void LifeTracker()
    {
        if (numberOfHearts == 3)
        {
            heartThree.enabled = true;
            heartTwo.enabled = true;
            heartOne.enabled = true;
        }

        if (numberOfHearts == 2)
        {
            heartTwo.enabled = true;
            heartOne.enabled = true;
            heartThree.enabled = false;

        }
        if (numberOfHearts == 1)
        {
            heartOne.enabled = true;
            heartThree.enabled = false;
            heartTwo.enabled = false;
        }
        if (numberOfHearts == 0)
        {
            heartThree.enabled = false;
            heartTwo.enabled = false;
            heartOne.enabled = false;
            gameOverUI.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public virtual void KillPlayer()
    {
        if (playerCurrentHealth <= 0)
        {
            Debug.Log("Player Dead");
            numberOfHearts -= 1;
            if (numberOfHearts == 2 || numberOfHearts == 1)
            {
                playerCurrentHealth = playerMaxHealth;
            }
        }
        
    }

    //Function to modify Damage and Armor
    /*
         void OnEquipmentChanged(Equipment newItem, Equipment oldItem)
    {
        if (newItem != null)
        {
            playerStats.playerArmor.AddModifier(newItem.armorModifier);
            playerStats.playerDamage.AddModifier(newItem.damageModifier);
        }

        if (oldItem != null)
        {
            playerStats.playerArmor.RemoveModifier(oldItem.armorModifier);
            playerStats.playerDamage.RemoveModifier(oldItem.damageModifier);
        }
    }
    */


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
