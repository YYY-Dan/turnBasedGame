using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pAction : MonoBehaviour
{
    private GameObject champion;
    private GameObject enemy;

    [SerializeField]
    private GameObject shootAttackPrefab;

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
        if (btn.CompareTo("shootAttack") == 0)
        {
            shootAttackPrefab.GetComponent<attScript>().Attack(victim);

        } else if (btn.CompareTo("skillAttack") == 0)
        {
            skillAttackPrefab.GetComponent<attScript>().Attack(victim);
        } else 
        {
            chargeManaPrefab.GetComponent<attScript>().Attack(victim);
        }
    }
}