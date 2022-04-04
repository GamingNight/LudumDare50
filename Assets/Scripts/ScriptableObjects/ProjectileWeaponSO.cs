using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileWeaponSO : AbstractWeaponSO
{
    public GameObject projectilePrefab;
    public float shootRate; //nb projectiles per second
    public float cooldownLossPerShoot;
    public float cooldownReloadRate; //percents per second
}
