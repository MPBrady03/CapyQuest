/************


Credit to Brackey for help with the Battle Manager System: https://www.youtube.com/watch?v=_1pz_ohupPs&t=132s


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // an extension for better looking text. Unity recommends this since the normal Text object is obselete.

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }  // different battle states
public class BattleSystem2 : MonoBehaviour
{
    public BattleState state; // holds the current state

    // holds the prefab of the different characters so they can be moved and edited for different battles
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    public GameObject player3Prefab;
    public GameObject player4Prefab;
    public GameObject enemyPrefab;

    // Gets the location of each battle station so that the characters can be placed there accordingly
    public Transform player1BattleStation;
    public Transform player2BattleStation;
    public Transform player3BattleStation;
    public Transform player4BattleStation;
    public Transform enemyBattleStation;

    // Defines each of the characters and enemies as Units
    Unit playerUnit1;
    Unit playerUnit2;
    Unit playerUnit3;
    Unit playerUnit4;
    Unit enemyUnit;

    // holds the different elements of each character's battlehud like name and level.
    public BattleHud player1HUD;
    public BattleHud player2HUD;
    public BattleHud player3HUD;
    public BattleHud player4HUD;
    public BattleHud enemyHUD;

    public TextMeshProUGUI dialogueText; // text that shows in the battlelog.
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetUpBattle()); // on start, set up battle. This is wrapped in a coroutine because of the WaitForSeconds function.
    }

    IEnumerator SetUpBattle(){ // gets all the needed data instantiated and sets player locations. Also replaces default text like names, levels, and battlelog.
        // Player Character initializing for all 4 characters
        GameObject playerGO1 = Instantiate(player1Prefab, player1BattleStation);
        playerUnit1 = playerGO1.GetComponent<Unit>();
        GameObject playerGO2 = Instantiate(player2Prefab, player2BattleStation);
        playerUnit2 = playerGO2.GetComponent<Unit>();
        GameObject playerGO3 = Instantiate(player3Prefab, player3BattleStation);
        playerUnit3 = playerGO3.GetComponent<Unit>();
        GameObject playerGO4 = Instantiate(player4Prefab, player4BattleStation);
        playerUnit4 = playerGO4.GetComponent<Unit>();

        // enemy initializing
        GameObject enemyGO = Instantiate(enemyPrefab, enemyBattleStation);
        enemyUnit = enemyGO.GetComponent<Unit>();

        dialogueText.text = "An enemy " + enemyUnit.unitName + " appeared!"; // default battlelog text

        // Sets the HUDS
        player1HUD.setHUD(playerUnit1);
        player2HUD.setHUD(playerUnit2);
        player3HUD.setHUD(playerUnit3);
        player4HUD.setHUD(playerUnit4);
        enemyHUD.setHUD(enemyUnit);

        yield return new WaitForSeconds(2f); // wait so player can read text

        state = BattleState.PLAYERTURN; // after set up, change to the PLAYERTURN state
        PlayerTurn();
    }

    IEnumerator PlayerAttack(){ // wait two seconds before changing to attack
        
        bool isIncapacitated = enemyUnit.takeDamage(playerUnit1.damage);
        enemyHUD.setHP(enemyUnit.currentHP);
        dialogueText.text = "The attack is successful.";
        yield return new WaitForSeconds(2f);
        if(isIncapacitated == true){
            state = BattleState.WON;
            endBattle();
        }
        else{
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }

    void endBattle(){
        if(state == BattleState.WON){
            dialogueText.text = "Victory!";
        }
        else if(state == BattleState.LOST){
            dialogueText.text = "Game Over";
        }
    }
    IEnumerator EnemyTurn(){
        dialogueText.text = enemyUnit.unitName + " attacks " + playerUnit2 + ".";
        yield return new WaitForSeconds(2f);
        bool isIncapacitated = playerUnit2.takeDamage(enemyUnit.damage);
        player2HUD.setHP(playerUnit2.currentHP);
        yield return new WaitForSeconds(2f);
        if(isIncapacitated){
            state = BattleState.LOST;
            endBattle();
        }
        else{
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void PlayerTurn(){ // when its the player's turn, change the text
        dialogueText.text = "Choose an action: ";
    }

    public void OnAttackButton(){ // when the attack button is pressed
        if(state != BattleState.PLAYERTURN){
            return;
        }
        StartCoroutine(PlayerAttack());
    }
}

*************/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // initializes variables to be editable in Unity for testing.
    public string unitName;
    public int unitLevel;
    public int currentHP;
    public int maxHP;
    public int damage;
    public int speed; // determines who goes first and in what order
    public int luck;

    public bool takeDamage(int dmg){
        currentHP -= dmg;
        if(currentHP <= 0){
            return true;
        }
        else{
            return false;
        }
    }
}

