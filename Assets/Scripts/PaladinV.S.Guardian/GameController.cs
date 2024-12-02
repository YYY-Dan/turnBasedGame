using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Transactions;
using UnityEngine.SocialPlatforms;
using TMPro;

public class GameController : MonoBehaviour
{
    private List<playerStats> playerStats;

    private GameObject battleMenu;

    public TextMeshProUGUI battleText;

    private void Awake()
    {
        battleMenu = GameObject.Find("actionMenu");
    }
    void Start()
    {
        playerStats = new List<playerStats>();
        GameObject champion = GameObject.FindGameObjectWithTag("Champion");
        playerStats currentPlayerStats = champion.GetComponent<playerStats>();
        currentPlayerStats.CalculateNextTurn(0);
        playerStats.Add(currentPlayerStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        playerStats currentEnemyStats = enemy.GetComponent<playerStats>();
        currentEnemyStats.CalculateNextTurn(0);
        playerStats.Add(currentEnemyStats);

        playerStats.Sort();
        

        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        playerStats currentPlayerStats = playerStats[0];
        playerStats.Remove(currentPlayerStats);
        if (!currentPlayerStats.GetDead())
        {
            GameObject currentUnit = currentPlayerStats.gameObject;
            currentPlayerStats.CalculateNextTurn(currentPlayerStats.nextActTurn);
            playerStats.Add(currentPlayerStats);
            playerStats.Sort();
            if(currentUnit.tag == "Champion")
            {
                this.battleMenu.SetActive(true);
            } else
            {
                this.battleMenu.SetActive(false);
                string attackType = Random.Range(0, 2) == 1 ? "meleeAttack" : "skillAttack";
                currentUnit.GetComponent<playerAction>().SelectAttack(attackType);
            }
        } else
        {
            NextTurn();
        }
    }
}