using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/ProjectileWeapon")]
public class ProjectileWeaponSO : AbstractWeaponSO
{
    public GameObject projectilePrefab;
    public Vector2 initProjectilePosition;

    public override void Activate(GameObject weapon) {
        GameObject projectile = Instantiate<GameObject>(projectilePrefab, weapon.transform);
        projectile.transform.localPosition = initProjectilePosition;
        projectile.GetComponent<ProjectileMovement>().direction = weapon.transform.right;
    }
}
