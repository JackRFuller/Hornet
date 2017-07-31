using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHandler : MonoBehaviour {

    [SerializeField]
    private Unit unit;
    public Unit Unit { get { return unit; } }

    //Components
    private UnitMovementHandler movementHandler;

    //Temp Attributes
    private float distanceMovedThisTurn;
    public float DistanceMovedThisTurn { get { return distanceMovedThisTurn; } }

    private void Awake()
    {
        //Called on Awake so unit movement doesn#t start too early
        movementHandler = this.GetComponent<UnitMovementHandler>();
        movementHandler.enabled = false;
    }

    public void StartMovingUnit()
    {
        //Disable Player from being able to pick other units
        EventManager.TriggerEvent(Events.DisableInteraction);
        
        movementHandler.GetKeyComponents();
    }
}
