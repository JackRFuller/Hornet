using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionHandler : MonoBehaviour
{
    public static Camera PlayerCamera;

    public static UnitHandler CurrentUnit;
    public static Unit CurrentSelectedUnit;

    private void OnEnable()
    {
        EventManager.StartListening(Events.EnableInteraction, TurnOnPlayerInteraction);
        EventManager.StartListening(Events.DisableInteraction, TurnOffPlayerInteraction);
    }

    private void OnDisable()
    {
        EventManager.StopListening(Events.EnableInteraction, TurnOnPlayerInteraction);
        EventManager.StopListening(Events.DisableInteraction, TurnOffPlayerInteraction);
    }

    private void Start()
    {
        PlayerCamera = this.GetComponent<Camera>(); 
    }


    // Update is called once per frame
    void Update ()
    {
        DetectObjects();
	}

    void DetectObjects()
    {
        Ray ray = PlayerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(Input.GetMouseButtonDown(0))
            {
                if (hit.collider.tag.Equals("PlayerOne_Unit"))
                {
                    SelectUnit(hit.collider.gameObject);
                }
            }           
        }
    }

    private void SelectUnit(GameObject unit)
    {
        UnitHandler newUnit = unit.GetComponent<UnitHandler>();

        if(CurrentUnit != newUnit)
        {
            CurrentUnit = newUnit;
            CurrentSelectedUnit = newUnit.Unit;            
        }

        EventManager.TriggerEvent(Events.SelectedUnit);

    }

    void TurnOffPlayerInteraction()
    {
        this.enabled = false;
    }

    void TurnOnPlayerInteraction()
    {
        this.enabled = true;
    }
}
