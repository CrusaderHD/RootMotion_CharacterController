using UnityEngine;

/*Handles interaction with the enemy*/
public class Enemy : Interactable
{
    PlayerManager playerManager;
    PlayerStats myStats;
    private void Start()
    {
        playerManager = PlayerManager.instance;

    }

    public override void Interact()
    {
        base.Interact();
        //Attack Enemy
        CharacterCombat playerCombat = playerManager.playerPrefab.GetComponent<CharacterCombat>();
        if (playerCombat != null)
        {
            playerCombat.Attack(myStats);
        }
    }


}
