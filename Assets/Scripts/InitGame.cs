using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    public GrandmaGenerator[] grandmaGenerators;
    public ProjectileWeaponHandler[] weaponHandlers;
    public WeaponSelectorSO weaponSelectorSO;
    public ScoreSO scoreSO;

    public void Init() {
        foreach (GrandmaGenerator generator in grandmaGenerators) {
            generator.Init();
        }
        foreach (ProjectileWeaponHandler weaponHandler in weaponHandlers) {
            weaponHandler.Init();
        }
        weaponSelectorSO.selectedWeapon = null;
        scoreSO.nbGrandmasRepelled = 0;
    }
}
