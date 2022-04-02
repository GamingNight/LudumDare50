using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{

    public AbstractWeaponSO weaponSO;

    void Start() {
        GetComponent<SpriteRenderer>().sprite = weaponSO.sprite;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0)) {
            weaponSO.Activate(gameObject);
        }
    }
}
