using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceHandler : MonoBehaviour
{
    //Components
    private Rigidbody diceRB;

    [SerializeField]
    private DiceSideHandler[] diceSideHandlers;
    private int diceValue;
    private Vector3 diceVelocity;
    private bool isMoving;
    private float forceIfStatic = 100f;
    private bool isOnGround = false;

    private void Start()
    {
        diceRB = this.GetComponent<Rigidbody>();

    }

    private void Update()
    {
        if(!IsDiceStillMoving())
        {
            diceValue = GetDiceValue();
            Debug.Log(diceValue);
        }
    }

    private bool IsDiceStillMoving()
    {
        if(diceRB.velocity.sqrMagnitude > 0.05f)
        {
            return true;
        }
        else
        {
            diceRB.velocity = Vector3.zero;
            return false;
        }
    }

    private int GetDiceValue()
    {
        for(int i = 0; i < diceSideHandlers.Length; i++)
        {
            if(diceSideHandlers[i].OnGround)
            {
                return 7 - diceSideHandlers[i].SideValue;
            }
        }

        return 0;
    }

}
