using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrandmaAnim : MonoBehaviour
{
    public Animator animator;
    void Update() {
        if (transform.position.x < 0.85f) {
            animator.SetTrigger("Transform");
        }
    }
}
