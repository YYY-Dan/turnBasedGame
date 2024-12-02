using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class makeButton : MonoBehaviour
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
        if (btn.CompareTo("shootBtn") == 0)
        {
            champion.GetComponent<pAction>().SelectAttack("shootAttack");
        } else if (btn.CompareTo("skillBtn") == 0)
        {
            champion.GetComponent<pAction>().SelectAttack("skillAttack");
        } else
        {
            champion.GetComponent<pAction>().SelectAttack("chargeMana");
        }
    }
}