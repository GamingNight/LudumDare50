using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponSO : ScriptableObject
{
    public Sprite sprite;
    public abstract bool Activate(GameObject weapon, float lastShootTime, float cooldownPercent);
}
