using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CooldownSlider : MonoBehaviour
{
    public ProjectileWeaponSO weaponSO;
    public RectTransform sliderFrontImage;

    private float maxValue;

    void Start() {
        maxValue = ((RectTransform)transform).sizeDelta.x;
    }

    void Update() {
        float cooldownPercent = weaponSO.GetCoolDownPercent();
        sliderFrontImage.offsetMax = new Vector2(-(maxValue - (cooldownPercent * maxValue / 100)), sliderFrontImage.offsetMax.y);
    }
}
