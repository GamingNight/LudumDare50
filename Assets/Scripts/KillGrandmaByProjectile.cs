using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGrandmaByProjectile : MonoBehaviour
{

    public ScoreSO scoreSO;
    public AudioSourceContainerSO audioContainerSO;
    public AudioSource source;
    public AudioClip[] deathClips;
    public Animator animator;

    private bool destroying;
    private float initPitch;
    private float initVolume;
    private bool deathAnimFinished;

    private void Start() {
        destroying = false;
        initPitch = source.pitch;
        initVolume = source.volume;
        deathAnimFinished = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Projectile" && !destroying) {
            scoreSO.nbGrandmasRepelled++;
            int clipIndex = Random.Range(0, deathClips.Length);
            audioContainerSO.AddSource(source);
            source.clip = deathClips[clipIndex];
            source.pitch = initPitch + Random.Range(-0.3f, 0.3f);
            source.volume = initVolume + Random.Range(-0.1f, 0.1f);
            source.Play();
            GetComponent<BoxCollider2D>().enabled = false;
            GetComponent<GrandmaMovement>().enabled = false;
            destroying = true;
            animator.SetTrigger("Death");
        }
    }

    public void DeathAnimFinished() {
        deathAnimFinished = true;
    }

    private void Update() {
        if (destroying && !source.isPlaying && deathAnimFinished) {
            audioContainerSO.RemoveSource(source);
            destroying = false;
            Destroy(gameObject, 2);
        }
    }
}
