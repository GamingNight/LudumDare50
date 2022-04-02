using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProjectileWeaponHandler : MonoBehaviour
{
    public ProjectileWeaponSO weaponSO;
    public CooldownPercentSO cooldownPercentSO;

    private float lastShootTime;
    private float lastCooldownTime;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = weaponSO.sprite;
        lastShootTime = 0;
        cooldownPercentSO.value = 100;
        lastCooldownTime = 0;
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            if (weaponSO.Activate(gameObject, lastShootTime, cooldownPercentSO.value)) {
                lastShootTime = Time.time;
                cooldownPercentSO.value = Mathf.Max(0, cooldownPercentSO.value - weaponSO.cooldownLossPerShoot);
            }
        } else {
            if (Time.time >= lastCooldownTime + (1f / weaponSO.cooldownReloadRate)) {
                cooldownPercentSO.value = Mathf.Min(100, cooldownPercentSO.value + (1f / weaponSO.cooldownReloadRate));
            }
        }
    }
}
