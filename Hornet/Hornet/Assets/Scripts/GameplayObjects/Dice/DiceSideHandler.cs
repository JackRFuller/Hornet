using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceSideHandler : MonoBehaviour
{

    // Use this for initialization
    private string groundLayer = "Default";
    [SerializeField]
    [Range(1,6)]
    private int sideValue;
    public int SideValue { get { return sideValue; } }
    private bool onGround = false;
    public bool OnGround { get { return onGround; } }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(groundLayer))
        {
            onGround = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer(groundLayer))
        {
            onGround = false;
        }
    }
}
