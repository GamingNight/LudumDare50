using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ProjectileWeaponHandler : MonoBehaviour
{
    public ProjectileWeaponSO weaponSO;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = weaponSO.sprite;
        weaponSO.InitWeapon();
    }

    void Update() {
        if (Input.GetMouseButton(0)) {
            weaponSO.Activate(gameObject);
        } else {
            weaponSO.ReloadCooldown();
        }
    }
}
