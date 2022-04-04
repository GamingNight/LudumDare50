using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapon/Grenade")]
public class GrenadeWeaponSO : ProjectileWeaponSO
{
    public override GameObject[] Activate(GameObject weapon, float lastShootTime, float cooldownPercent, Vector2 spawnPosition) {
        if (Time.time >= lastShootTime + (1f / shootRate)) {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.parent = weapon.transform.parent;
            projectile.transform.position = spawnPosition;
            projectile.GetComponent<ProjectileStraightMovement>().direction = weapon.transform.right;
            return new GameObject[] { projectile };
        } else {
            return null;
        }
    }
}
