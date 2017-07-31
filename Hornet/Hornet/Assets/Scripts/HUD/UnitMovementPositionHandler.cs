using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UnitMovementPositionHandler : MonoSingleton<UnitMovementPositionHandler>
{
    [Header("Sprite Components")]
    [SerializeField]
    private SpriteRenderer[] sprites;

    [Header("HUD Components")]
    [SerializeField]
    private TMP_Text distanceToPoint;

    private void Start()
    {
        TurnOffPositionPointer();
    }

    public void TurnOnPositionPointer()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].enabled = true;
        }

        distanceToPoint.GetComponent<TextMeshProUGUI>().enabled = true;
    }

    public void TurnOffPositionPointer()
    {
        for (int i = 0; i < sprites.Length; i++)
        {
            sprites[i].enabled = false;
        }

        distanceToPoint.GetComponent<TextMeshProUGUI>().enabled = false;
    }

    public void MovePointerToTargetPosition(Vector3 targetPos)
    {
        this.transform.position = targetPos;
    }

    public void SetDistanceToPoint(float distance)
    {
        distanceToPoint.text = distance.ToString("F1");
    }
}
