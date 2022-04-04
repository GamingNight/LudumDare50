using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProjectileWeaponHandler : MonoBehaviour
{
    public ProjectileWeaponSO weaponSO;
    public CooldownPercentSO cooldownPercentSO;
    public WeaponSelectorSO weaponSelectorSO;
    public float minOrientation;
    public float maxOrientation;
    public Transform shootPoint;

    private float lastShootTime;
    private float lastCooldownTime;
    private List<GameObject> instantiatedProjectiles;

    void Start() {
        Init();
    }

    public void Init() {
        if (instantiatedProjectiles == null) {
            instantiatedProjectiles = new List<GameObject>();
        }
        foreach (GameObject projectile in instantiatedProjectiles) {
            Destroy(projectile);
        }
        instantiatedProjectiles.Clear();
        lastShootTime = 0;
        cooldownPercentSO.value = 100;
        lastCooldownTime = 0;
    }

    void Update() {

        if (weaponSelectorSO.selectedWeapon == gameObject) {
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            difference.Normalize();
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            rotationZ = Mathf.Clamp(rotationZ, minOrientation, maxOrientation);
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
            //Debug.DrawLine(shootPoint.position, Camera.main.ScreenToWorldPoint(Input.mousePosition), Color.red);
        }

        if (Input.GetMouseButton(0) && weaponSelectorSO.selectedWeapon == gameObject) {
            GameObject projectile = weaponSO.Activate(gameObject, lastShootTime, cooldownPercentSO.value, shootPoint.position);
            if (projectile != null) {
                lastShootTime = Time.time;
                cooldownPercentSO.value = Mathf.Max(0, cooldownPercentSO.value - weaponSO.cooldownLossPerShoot);
                instantiatedProjectiles.Add(projectile);
            }
        } else {
            if (Time.time >= lastCooldownTime + (1f / weaponSO.cooldownReloadRate)) {
                cooldownPercentSO.value = Mathf.Min(100, cooldownPercentSO.value + (1f / weaponSO.cooldownReloadRate));
            }
        }

    }
}
