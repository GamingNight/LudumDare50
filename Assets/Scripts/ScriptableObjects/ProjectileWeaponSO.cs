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

    private float lastShootTime;
    private float cooldownPercent;
    private float lastCooldownTime;

    public override void Activate(GameObject weapon) {
        if (Time.time >= lastShootTime + (1f / shootRate) && cooldownPercent > 0) {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab, weapon.transform);
            projectile.transform.localPosition = initProjectilePosition;
            projectile.GetComponent<ProjectileMovement>().direction = weapon.transform.right;
            lastShootTime = Time.time;
            cooldownPercent = Mathf.Max(0, cooldownPercent - cooldownLossPerShoot);
        }
    }

    public void ReloadCooldown() {
        if (Time.time >= lastCooldownTime + (1f / cooldownReloadRate)) {
            cooldownPercent = Mathf.Min(100, cooldownPercent + (1f / cooldownReloadRate));
        }
    }

    public override void InitWeapon() {
        lastShootTime = 0;
        cooldownPercent = 100;
        lastCooldownTime = 0;
    }

    public float GetCoolDownPercent() {
        return cooldownPercent;
    }
}
