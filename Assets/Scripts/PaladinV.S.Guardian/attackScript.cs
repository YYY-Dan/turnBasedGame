using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string animationName;

    [SerializeField]
    private bool meleeAttack;

    [SerializeField]
    private bool skillAttack;

    [SerializeField]
    private bool chargeMana;

    [SerializeField]
    private float manaCost;

    [SerializeField]
    private float minAttackMultiplier;

    [SerializeField]
    private float maxAttackMultiplier;
    
    [SerializeField]
    private float minDefenseMultiplier;

    [SerializeField]
    private float maxDefenseMultiplier;

    private playerStats attackerStats;
    private playerStats targetStats;
    private float getHit = 0.0f;
    
    public void Attack(GameObject victim)
    {
        attackerStats = owner.GetComponent<playerStats>();
        targetStats = victim.GetComponent<playerStats>();
        if (attackerStats.mana >= manaCost)
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);

            if (chargeMana) {
                owner.GetComponent<Animator>().Play(animationName);
                attackerStats.updateManaFill(manaCost);
                Invoke("SkipTurnContinueGame", 2);
            } else {
                getHit = multiplier * attackerStats.meleeAttack;
                if (skillAttack) {
                    getHit = multiplier * attackerStats.skillAttack;
                }
                float defenseMultiplier = Random.Range(minDefenseMultiplier, maxDefenseMultiplier);
                getHit = Mathf.Max(0, getHit - (defenseMultiplier * targetStats.defense));
                owner.GetComponent<Animator>().Play(animationName);
                targetStats.ReceiveDamage(Mathf.CeilToInt(getHit));
                attackerStats.updateManaFill(manaCost);
            }
        } else {
            Invoke("SkipTurnContinueGame", 2);
        }
    }

    void SkipTurnContinueGame()
    {
        GameObject.Find("GameControllerObject").GetComponent<GameController>().NextTurn();
    }
}