using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGrandmaAnim : MonoBehaviour
{
    public Animator animator;
    public AudioSource kissAudioSource;
    public AudioSourceContainerSO audioContainerSO;

    private bool animTriggered;
    private float initPitch;
    private float initVolume;

    private void Start() {
        animTriggered = false;
        initPitch = kissAudioSource.pitch;
        initVolume = kissAudioSource.volume;
    }
    void Update() {
        if (transform.position.x < 0.85f && !animTriggered) {
            kissAudioSource.pitch = initPitch + Random.Range(-0.3f, 0.3f);
            kissAudioSource.volume = initVolume + Random.Range(-0.1f, 0.1f);
            kissAudioSource.Play();
            audioContainerSO.AddSource(kissAudioSource);
            animator.SetTrigger("Transform");
            animTriggered = true;
        }
    }
}
