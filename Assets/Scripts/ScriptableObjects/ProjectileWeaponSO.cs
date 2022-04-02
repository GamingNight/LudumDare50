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

    public override bool Activate(GameObject weapon, float lastShootTime, float cooldownPercent) {
        if (Time.time >= lastShootTime + (1f / shootRate) && cooldownPercent > 0) {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab, weapon.transform);
            projectile.transform.localPosition = initProjectilePosition;
            projectile.GetComponent<ProjectileMovement>().direction = weapon.transform.right;
            return true;
        } else {
            return false;
        }
    }
}
