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
    public AudioSource shootSource;

    private float lastShootTime;
    private float lastCooldownTime;
    private List<GameObject> instantiatedProjectiles;
    private float shootSourceInitPitch;
    private float shootSourceInitVolume;

    void Start() {
        shootSourceInitPitch = shootSource.pitch;
        shootSourceInitVolume = shootSource.volume;
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
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - shootPoint.position;
            difference.Normalize();
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            rotationZ = Mathf.Clamp(rotationZ, minOrientation, maxOrientation);
            transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        }

        if (Input.GetMouseButton(0) && weaponSelectorSO.selectedWeapon == gameObject && cooldownPercentSO.value >= weaponSO.cooldownLossPerShoot) {
            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            GameObject[] projectiles = weaponSO.Activate(gameObject, lastShootTime, cooldownPercentSO.value, shootPoint.position, target);
            if (projectiles != null && projectiles.Length > 0) {
                lastShootTime = Time.time;
                cooldownPercentSO.value = Mathf.Max(0, cooldownPercentSO.value - weaponSO.cooldownLossPerShoot);
                instantiatedProjectiles.AddRange(projectiles);
                foreach (GameObject projectile in projectiles) {
                    SpriteRenderer[] spriteRenderers = projectile.GetComponentsInChildren<SpriteRenderer>();
                    foreach (SpriteRenderer spriteRenderer in spriteRenderers) {
                        spriteRenderer.sortingLayerID = GetComponent<SpriteRenderer>().sortingLayerID;
                    }
                }
                shootSource.pitch = shootSourceInitPitch + Random.Range(-0.3f, 0.3f);
                shootSource.volume = shootSourceInitVolume + Random.Range(-0.1f, 0.1f);
                shootSource.Play();
            }
        } else {
            if (cooldownPercentSO.value < 100) {
                cooldownPercentSO.value = Mathf.Min(100, cooldownPercentSO.value + (100 * Time.deltaTime / weaponSO.cooldownReloadDuration));
            }
        }

    }
}
