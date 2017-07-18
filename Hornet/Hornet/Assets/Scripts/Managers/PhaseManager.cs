using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhaseManager : MonoSingleton<PhaseManager>
{
    //Turns
    private int turnCount = 1;
    public int TurnCount { get { return turnCount; } }

    //Phases
    [SerializeField]
    private Phase[] phases;
    public Phase[] Phases { get { return phases; } }
    private int phaseIndex;
    public int PhaseIndex { get { return phaseIndex; } }

    [System.Serializable]
    public class Phase
    {
        public string phaseName;
    }

    private void OnEnable()
    {
        EventManager.StartListening(Events.EndPhase, CycleThroughPhases);   
    }

    private void OnDisable()
    {
        EventManager.StopListening(Events.EndPhase, CycleThroughPhases);
    }

    private void CycleThroughPhases()
    {
        phaseIndex++;
        if (phaseIndex == phases.Length)
        {
            phaseIndex = 0;
            turnCount++;

            EventManager.TriggerEvent(Events.NewTurn);
        }
            
    }
}
