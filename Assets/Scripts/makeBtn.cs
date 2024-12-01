using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeButton : MonoBehaviour
{
    [SerializeField]
    private bool physical;
    public GameObject champion;
    void Start()
    {
        gameObject.GetComponent<Button>().onClick.AddListener(() => AttachCallback(gameObject.name));
        champion = GameObject.FindGameObjectWithTag("Champion");
    }

    private void AttachCallback(string btn)
    {
        if (btn.CompareTo("meleeBtn") == 0)
        {
            champion.GetComponent<playerAction>().SelectAttack("meleeAttack");
        } else if (btn.CompareTo("skillBtn") == 0)
        {
            champion.GetComponent<playerAction>().SelectAttack("skillAttack");
        } else
        {
            champion.GetComponent<playerAction>().SelectAttack("chargeMana");
        }
    }
}