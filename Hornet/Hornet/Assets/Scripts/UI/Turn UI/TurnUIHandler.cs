using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TurnUIHandler : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField]
    private TMP_Text turnCountText;

    private void OnEnable()
    {
        EventManager.StartListening(Events.NewTurn, UpdateTurnCount);
    }

    private void OnDisable()
    {
        EventManager.StopListening(Events.NewTurn, UpdateTurnCount);
    }

    // Use this for initialization
    void Start ()
    {
        UpdateTurnCount();
	}

    private void UpdateTurnCount()
    {
        string turnCountString = null;
        int turnCount = PhaseManager.Instance.TurnCount;

        if(turnCount < 10)
        {
            turnCountString = "00" + turnCount.ToString();
        }
        else if(turnCount >= 10 && turnCount < 100)
        {
            turnCountString = "0" + turnCount.ToString();
        }
        else
        {
            turnCountString = turnCount.ToString();
        }

        turnCountText.text = turnCountString;
    }
	
	
}
