using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Unit", menuName = "ScriptableObject/Create New Unit", order = 1)]
public class Unit : ScriptableObject
{
    public string unitName;
    
    [Range(1,50)]
    public int MovementDistance;
    public int Combat;
    public int Shooting;
    public int Strength;
    public int Defense;
    public int AttackCount;
    public int HealthPoints;
    public int Fortitude;

    public int Might;
    public int Will;
    public int Fate;
	
}
