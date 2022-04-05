using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillGrandmaByProjectile : MonoBehaviour
{

    public ScoreSO scoreSO;
    public AudioSourceContainerSO audioContainerSO;
    public AudioSource source;
    public AudioClip[] deathClips;

    private bool destroying;
    private float initPitch;
    private float initVolume;

    private void Start() {
        destroying = false;
        initPitch = source.pitch;
        initVolume = source.volume;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Projectile" && !destroying) {
            scoreSO.nbGrandmasRepelled++;
            int clipIndex = Random.Range(0, deathClips.Length);
            audioContainerSO.AddSource(source);
            source.clip = deathClips[clipIndex];
            source.Play();
            source.pitch = initPitch + Random.Range(-0.3f, 0.3f);
            source.volume = initVolume + Random.Range(-0.1f, 0.1f);
            foreach(SpriteRenderer sr in GetComponentsInChildren<SpriteRenderer>()) {
                sr.enabled = false;
            }
            GetComponent<BoxCollider2D>().enabled = false;
            destroying = true;
        }
    }

    private void Update() {
        if (destroying && !source.isPlaying) {
            audioContainerSO.RemoveSource(source);
            destroying = false;
            Destroy(gameObject);
        }
    }
}
