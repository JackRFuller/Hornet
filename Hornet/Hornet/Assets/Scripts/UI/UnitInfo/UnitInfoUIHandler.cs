using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitInfoUIHandler : MonoBehaviour
{
    //Unit Components
    private UnitHandler selectedUnit;
    private Unit unitAttributes;

    private Animator unitUIAnim;

    [Header("UI Elements")]
    [SerializeField]
    private TMP_Text unitName;


    [Header("Player Actions")]
    [SerializeField]
    private Transform actionButtons;
    [SerializeField]
    private GameObject movementActionButton;

    private void OnEnable()
    {
        EventManager.StartListening(Events.SelectedUnit, PlayerHasSelectedNewUnit);
    }

    private void OnDisable()
    {
        EventManager.StopListening(Events.SelectedUnit, PlayerHasSelectedNewUnit);
    }

    private void Start()
    {
        unitUIAnim = this.GetComponent<Animator>();
        unitUIAnim.enabled = false; //Turn off UI to stop animation triggering prematurely
    }

    private void PlayerHasSelectedNewUnit()
    {
        selectedUnit = PlayerInteractionHandler.CurrentUnit;
        unitAttributes = PlayerInteractionHandler.CurrentSelectedUnit;

        //Set UI To Unit Attributes
        unitName.text = unitAttributes.unitName;

        //Set Available Player Actions
        SetAvailablePlayerActions();

        //Check if UI is showing - if not bring out
        ShowUIPanel();
    }

    private void SetAvailablePlayerActions()
    {
        foreach(Transform child in actionButtons)
        {
            child.gameObject.SetActive(false);
        }

        switch(PhaseManager.Instance.Phases[PhaseManager.Instance.PhaseIndex].phaseName)
        {
            case "Priority":
                break;
            case "Movement":
                if(selectedUnit.DistanceMovedThisTurn < unitAttributes.MovementDistance)
                {
                    movementActionButton.SetActive(true);
                }
                break;
            case "Shooting":
                break;
            case "Combat":
                break;
        }
    }

    public void CloseUIPanel()
    {
        unitUIAnim.SetBool("isShowingUIPanel", false);
    }

    public void ShowUIPanel()
    {
        if (!unitUIAnim.enabled)
            unitUIAnim.enabled = true;

        unitUIAnim.SetBool("isShowingUIPanel", true);
    }

    //Player Actions
    public void OnClickStartMoving()
    {
        CloseUIPanel();
        selectedUnit.StartMovingUnit();
    }

    public void OnClickStartShooting()
    {

    }

}
