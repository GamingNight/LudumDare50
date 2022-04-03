using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitGame : MonoBehaviour
{
    public GrandmaGenerator[] grandmaGenerators;
    public ProjectileWeaponHandler[] weaponHandlers;

    public void Init() {
        foreach (GrandmaGenerator generator in grandmaGenerators) {
            generator.Init();
        }
        foreach (ProjectileWeaponHandler weaponHandler in weaponHandlers) {
            weaponHandler.Init();
        }
    }
}
