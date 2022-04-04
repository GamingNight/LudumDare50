using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWeaponWithKey : MonoBehaviour
{
    public GameObject[] weapons;
    public WeaponSelectorSO selectorSO;

    private int index;

    void Update() {

        bool update = false;
        index = GetCurrentIndex();
        if (Input.GetButtonDown("Down")) {
            index++;
            if (index > weapons.Length - 1)
                index = 0;
            update = true;
        }
        if (Input.GetButtonDown("Up")) {
            index--;
            if (index < 0)
                index = weapons.Length - 1;
            update = true;
        }

        if (update) {
            selectorSO.selectedWeapon = weapons[index];
        }
    }

    private int GetCurrentIndex() {

        int crtIndex = 0;
        if (selectorSO.selectedWeapon != null) {
            int indexOf = Array.IndexOf(weapons, selectorSO.selectedWeapon);
            if (indexOf != -1) {
                crtIndex = indexOf;
            }
        }
        return crtIndex;
    }
}
