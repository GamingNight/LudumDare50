using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCurvedMovement : MonoBehaviour
{
    public ProjectileSO projectileSO;
    public Vector2 target;
    public GameObject zoneDamageObject;
    public AudioSource boomSource;

    private Vector2 initPoint;
    private float speed;
    private float distance;
    private float totalDuration;
    private float durationSoFar;
    private bool stopMovement;
    private float boomInitPitch;
    private float boomInitVolume;
    void Start() {
        initPoint = transform.position;
        speed = projectileSO.speed;
        //distance = (target - initPoint).magnitude;
        distance = 3;
        totalDuration = distance / speed;
        durationSoFar = 0;
        stopMovement = false;
        boomInitPitch = boomSource.pitch;
        boomInitVolume = boomSource.volume;
    }

    void Update() {
        if (!stopMovement) {
            Vector3 p1 = initPoint + ((target - initPoint) / 2f) + (Vector2.Perpendicular(target - initPoint).normalized * 2f);
            float t = durationSoFar / totalDuration;
            transform.position = CalculateQuadraticBezierPoint(t, initPoint, p1, target);
            Debug.DrawLine(initPoint, p1, Color.red);
            Debug.DrawLine(p1, target, Color.red);
            Debug.DrawLine(initPoint, target, Color.red);
            durationSoFar += Time.deltaTime;

            if (t >= 1)
                TriggerExplosion();
        }

    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2) {
        //B(t) = (1-t)^2P0 + 2(t-1)tP1 + t^2P2
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        return uu * p0 + 2 * u * t * p1 + tt * p2;
    }

    private void TriggerExplosion() {
        zoneDamageObject.SetActive(true);
        boomSource.pitch = boomInitPitch + Random.Range(-0.3f, 0.3f);
        boomSource.volume = boomInitVolume + Random.Range(-0.1f, 0.1f);
        boomSource.Play();
        GetComponent<SpriteRenderer>().enabled = false;
        stopMovement = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Grandma") {
            TriggerExplosion();
        }
    }

    public void DestroyMe() {
        Destroy(gameObject);
    }
}
