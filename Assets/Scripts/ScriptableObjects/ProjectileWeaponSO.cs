using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ProjectileWeapon")]
public class ProjectileWeaponSO : AbstractWeaponSO
{
    public GameObject projectilePrefab;
    public Vector2 initProjectilePosition;
    public float shootRate; //nb projectiles per second
    public float cooldownLossPerShoot;
    public float cooldownReloadRate; //percents per second

    public override GameObject Activate(GameObject weapon, float lastShootTime, float cooldownPercent, Vector2 spawnPosition) {
        if (Time.time >= lastShootTime + (1f / shootRate) && cooldownPercent > 0) {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab);
            projectile.transform.parent = weapon.transform.parent;
            projectile.transform.position = spawnPosition;
            projectile.transform.rotation = weapon.transform.rotation;
            projectile.GetComponent<ProjectileMovement>().direction = weapon.transform.right;
            return projectile;
        } else {
            return null;
        }
    }
}
