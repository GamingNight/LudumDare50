using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Weapon/Shotgun")]
public class ShotgunWeaponSO : ProjectileWeaponSO
{
    public override GameObject[] Activate(GameObject weapon, float lastShootTime, float cooldownPercent, Vector2 spawnPosition) {
        if (Time.time >= lastShootTime + (1f / shootRate)) {
            GameObject projectile1 = Instantiate<GameObject>(projectilePrefab);
            projectile1.transform.parent = weapon.transform.parent;
            projectile1.transform.position = spawnPosition;
            projectile1.transform.eulerAngles = weapon.transform.eulerAngles + new Vector3(15, 0, 0);
            Vector2 direction1 = Quaternion.Euler(0, 0, 15) * weapon.transform.right;
            projectile1.GetComponent<ProjectileStraightMovement>().direction = direction1;


            GameObject projectile2 = Instantiate<GameObject>(projectilePrefab);
            projectile2.transform.parent = weapon.transform.parent;
            projectile2.transform.position = spawnPosition;
            projectile2.transform.eulerAngles = weapon.transform.eulerAngles + new Vector3(-15, 0, 0);
            Vector2 direction2 = Quaternion.Euler(0, 0, -15) * weapon.transform.right;
            projectile2.GetComponent<ProjectileStraightMovement>().direction = direction2;

            //Debug.Log("right = " + weapon.transform.right + ", d1 = " + direction1 + ", d2 = " + direction2);
            return new GameObject[] { projectile1, projectile2 };
        } else {
            return null;
        }
    }
}
