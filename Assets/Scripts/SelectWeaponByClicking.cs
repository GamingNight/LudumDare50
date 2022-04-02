using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeaponByClicking : MonoBehaviour
{
    public WeaponSelectorSO selector;
    public GameObject weaponToSelect;

    private void OnMouseDown() {
        selector.selectedWeapon = weaponToSelect;
    }
}
