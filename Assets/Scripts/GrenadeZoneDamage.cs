using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeZoneDamage : MonoBehaviour
{
    public void DestroyGrenade() {
        Destroy(transform.parent.gameObject);
    }
}
