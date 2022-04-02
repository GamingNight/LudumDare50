using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplaySelectedWeapon : MonoBehaviour
{
    public WeaponSelectorSO weaponSelectorSO;
    public GameObject thisWeapon;

    private Image image;

    void Start() {
        image = GetComponent<Image>();
    }

    void Update() {
        image.enabled = weaponSelectorSO.selectedWeapon == thisWeapon;
    }
}
