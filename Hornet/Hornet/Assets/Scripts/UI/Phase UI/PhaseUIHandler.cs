using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PhaseUIHandler : MonoBehaviour
{
    //Components
    private PhaseManager phaseManager;    

    [Header("UI Objects")]
    [SerializeField]
    private TMP_Text phaseTitleText;
    

    private void Start()
    {
        //Get Phase Manager
        phaseManager = PhaseManager.Instance;

        //Set Initial Phase
        phaseTitleText.text = phaseManager.Phases[0].phaseName;
    }

    public void EndPhase()
    {
        //Cycle through Phases
        EventManager.TriggerEvent(Events.EndPhase);

        //Update Phase UI
        phaseTitleText.text = phaseManager.Phases[PhaseManager.Instance.PhaseIndex].phaseName;
    }
}
