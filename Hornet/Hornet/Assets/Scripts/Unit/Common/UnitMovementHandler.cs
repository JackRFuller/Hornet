using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class UnitMovementHandler : MonoBehaviour
{
    //Components
    private UnitHandler unitHandler;
    private Unit unitAttributes;
    private NavMeshAgent navAgent;
    private NavMeshPath navMeshPath;
    private Camera playerCamera; //Used to send out ray

    private bool hasAllocatedComponents;

    /// <summary>
    /// Called From Unit Handler
    /// </summary>
    public void GetKeyComponents()
    {
       if(!hasAllocatedComponents)
        {
            UnitMovementPositionHandler.Instance.TurnOnPositionPointer();

            unitHandler = this.GetComponent<UnitHandler>();
            unitAttributes = unitHandler.Unit;

            navAgent = this.GetComponent<NavMeshAgent>();
            navMeshPath = new NavMeshPath();

            playerCamera = PlayerInteractionHandler.PlayerCamera;
            

            hasAllocatedComponents = true;
        }        

        this.enabled = true;
    }

    private void Update()
    {
        DetermineMovementPosition();
    }

    private void DetermineMovementPosition()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.collider.tag.Equals("Ground"))
            {
                //Draw Path To Point
                UnitMovementPositionHandler.Instance.MovePointerToTargetPosition(hit.point);

                //Calculate Path to Point
                navAgent.CalculatePath(hit.point, navMeshPath);
                
                //Debug Path
                for(int i = 0; i < navMeshPath.corners.Length - 1; i++)
                {
                    Debug.DrawLine(navMeshPath.corners[i], navMeshPath.corners[i + 1], Color.red);
                }

                //Calculate Length of Path
                float lengthOfPath = 0.0f;
                if(navMeshPath.status == NavMeshPathStatus.PathComplete && navMeshPath.corners.Length > 1)
                {
                    for (int i = 1; i < navMeshPath.corners.Length; i++)
                    {
                        lengthOfPath += Vector3.Distance(navMeshPath.corners[i - 1], navMeshPath.corners[i]);
                    }
                }

                //Send Distance To HUD
                UnitMovementPositionHandler.Instance.SetDistanceToPoint(lengthOfPath);

                //Player Clicks
                if(Input.GetMouseButtonUp(0))
                {
                    //Check it meets criteria

                    //Move Player to Position
                }
            }
        }
    }





}
