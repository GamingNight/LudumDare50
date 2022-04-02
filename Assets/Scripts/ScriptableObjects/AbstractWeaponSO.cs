using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWeaponSO : ScriptableObject
{
    public Sprite sprite;
    public abstract void Activate(GameObject weapon);
    public abstract void InitWeapon();
}
