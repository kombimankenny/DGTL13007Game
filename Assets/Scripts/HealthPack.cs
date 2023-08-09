using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : MonoBehaviour
{
    [SerializeField] private int healAmount = 1;

    public int GetHealAmount()
    {
        return healAmount;
    }
}
