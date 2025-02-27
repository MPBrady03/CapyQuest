using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem2 : MonoBehaviour
{
    public BattleState state;

    // Lists to manage players and their data dynamically
    public List<GameObject> playerPrefabs; // Player prefabs
    public List<Transform> playerBattleStations; // Player battle stations
    private List<Unit> playerUnits = new List<Unit>(); // Player unit instances
    public List<BattleHud> playerHUDs; // Player HUDs

    public GameObject enemyPrefab;
    public Transform enemyBattleStation;
    private Unit enemyUnit;
    public BattleHud enemyHUD;

    public TextMeshProUGUI dialogueText; // need to use textmeshpro, not just normal text

    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle());
    }

    IEnumerator SetUpBattle()
    {
        // Initialize player units
        for (int i = 0; i < playerPrefabs.Count; i++)
        {
            GameObject playerGO = Instantiate(playerPrefabs[i], playerBattleStations[i]);
            Unit playerUnit = playerGO.GetComponent<Unit>();
            playerUnits.Add(playerUnit);

            // Set up HUD for each player unit
            playerHUDs[i].setHUD(playerUnit);
        }

        // Initialize enemy
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();
        enemyHUD.setHUD(enemyUnit);

        dialogueText.text = "An enemy " + enemyUnit.unitName + " appeared!";
        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        // Target enemy for simplicity
        bool isIncapacitated = enemyUnit.takeDamage(playerUnits[0].damage); // Example: First player's damage
        enemyHUD.setHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful.";
        yield return new WaitForSeconds(2f);

        if (isIncapacitated)
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    void EndBattle()
    {
        if (state == BattleState.WON)
        {
            dialogueText.text = "Victory!";
        }
        else if (state == BattleState.LOST)
        {
            dialogueText.text = "Game Over";
        }
    }

    IEnumerator EnemyTurn()
    {
       // Select a random player to target
    int randomIndex = Random.Range(0, playerUnits.Count);
    Unit targetUnit = playerUnits[randomIndex];

    dialogueText.text = enemyUnit.unitName + " attacks " + targetUnit.unitName + "."; // updates battlelog to tell player who is being attacked.
    yield return new WaitForSeconds(2f);

    bool isIncapacitated = targetUnit.takeDamage(enemyUnit.damage);

    // Update the HUD of the targeted unit
    playerHUDs[randomIndex].setHP(targetUnit.currentHP);
    yield return new WaitForSeconds(2f);

    if (isIncapacitated)
    {
        // Remove the incapacitated player unit from the list
        playerUnits.RemoveAt(randomIndex); // removes character from list to be targeted if they are KO'd
        playerHUDs.RemoveAt(randomIndex);

        // Check if all player units are incapacitated
        if (playerUnits.Count == 0)
        {
            state = BattleState.LOST;
            EndBattle();
            yield break;
        }
    }

    // If battle is not lost, transition back to the player's turn
    state = BattleState.PLAYERTURN;
    PlayerTurn();
    }

    void PlayerTurn()
    {
        dialogueText.text = "Choose an action: ";
    }

    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN)
        {
            return;
        }
        StartCoroutine(PlayerAttack());
    }
}