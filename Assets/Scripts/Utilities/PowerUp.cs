using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]

public class PowerUp
{
    public GameObject powerUp;
    [Range(0,100)] public float spawnChance;
}
