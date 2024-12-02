using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerAction : MonoBehaviour
{
    private GameObject champion;
    private GameObject enemy;

    [SerializeField]
    private GameObject meleeAttackPrefab;

    [SerializeField]
    private GameObject skillAttackPrefab;

    [SerializeField]
    private GameObject chargeManaPrefab;

    [SerializeField]
    private Sprite faceIcon;

    private GameObject currentAttack;
    
    void Awake()
    {
        champion = GameObject.FindGameObjectWithTag("Champion");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }
    public void SelectAttack(string btn)
    {
        GameObject victim = champion;
        if (tag == "Champion")
        {
            victim = enemy;
        }
        if (btn.CompareTo("meleeAttack") == 0)
        {
            meleeAttackPrefab.GetComponent<attackScript>().Attack(victim);

        } else if (btn.CompareTo("skillAttack") == 0)
        {
            skillAttackPrefab.GetComponent<attackScript>().Attack(victim);
        } else 
        {
            chargeManaPrefab.GetComponent<attackScript>().Attack(victim);
        }
    }
}