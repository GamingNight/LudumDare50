using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    public GrandmaGenerator[] grandmaGenerators;
    public ProjectileWeaponHandler[] weaponHandlers;
    public WeaponSelectorSO weaponSelectorSO;
    public ScoreSO scoreSO;
    public int defaultWeaponIndex;
    public SetDifficulty setDifficultyScript;

    public void Init() {
        foreach (GrandmaGenerator generator in grandmaGenerators) {
            generator.Init();
        }
        foreach (ProjectileWeaponHandler weaponHandler in weaponHandlers) {
            weaponHandler.Init();
        }
        weaponSelectorSO.selectedWeapon = weaponHandlers[defaultWeaponIndex].gameObject;
        scoreSO.nbGrandmasRepelled = 0;
        setDifficultyScript.difficulty = SetDifficulty.Difficulty.SUPER_EASY;
    }
}
