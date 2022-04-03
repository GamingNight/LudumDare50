using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponSO : ScriptableObject
{
    public abstract bool Activate(GameObject weapon, float lastShootTime, float cooldownPercent);
}
