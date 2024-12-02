using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Transactions;
using UnityEngine.SocialPlatforms;
using TMPro;

public class gameController : MonoBehaviour
{
    private List<pStats> playerStats;

    private GameObject battleMenu;

    public TextMeshProUGUI battleText;

    private void Awake()
    {
        battleMenu = GameObject.Find("actionMenu");
    }
    void Start()
    {
        playerStats = new List<pStats>();
        GameObject champion = GameObject.FindGameObjectWithTag("Champion");
        pStats currentPlayerStats = champion.GetComponent<pStats>();
        currentPlayerStats.CalculateNextTurn(0);
        playerStats.Add(currentPlayerStats);

        GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        pStats currentEnemyStats = enemy.GetComponent<pStats>();
        currentEnemyStats.CalculateNextTurn(0);
        playerStats.Add(currentEnemyStats);

        playerStats.Sort();
        

        NextTurn();
    }

    public void NextTurn()
    {
        battleText.gameObject.SetActive(false);
        pStats currentPlayerStats = playerStats[0];
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
                string attackType = Random.Range(0, 2) == 1 ? "shootAttack" : "skillAttack";
                currentUnit.GetComponent<pAction>().SelectAttack(attackType);
            }
        } else
        {
            NextTurn();
        }
    }
}