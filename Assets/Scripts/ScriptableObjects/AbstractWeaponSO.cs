using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponSO : ScriptableObject
{
    public abstract GameObject Activate(GameObject weapon, float lastShootTime, float cooldownPercent, Vector2 spawnPosition);
}
