using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attScript : MonoBehaviour
{
    public GameObject owner;

    [SerializeField]
    private string animationName;

    [SerializeField]
    private bool shootAttack;

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

    private pStats attackerStats;
    private pStats targetStats;
    private float getHit = 0.0f;
    
    public void Attack(GameObject victim)
    {
        attackerStats = owner.GetComponent<pStats>();
        targetStats = victim.GetComponent<pStats>();
        if (attackerStats.mana >= manaCost)
        {
            float multiplier = Random.Range(minAttackMultiplier, maxAttackMultiplier);

            if (chargeMana) {
                owner.GetComponent<Animator>().Play(animationName);
                attackerStats.updateManaFill(manaCost);
                Invoke("SkipTurnContinueGame", 2);
            } else {
                getHit = multiplier * attackerStats.shootAttack;
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
        GameObject.Find("GameControllerObject").GetComponent<gameController>().NextTurn();
    }
}