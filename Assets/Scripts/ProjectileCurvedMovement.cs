using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCurvedMovement : MonoBehaviour
{
    public ProjectileSO projectileSO;
    public Vector2 target;

    private Vector2 initPoint;
    private float speed;
    private float distance;
    private float totalDuration;
    private float durationSoFar;
    void Start() {
        initPoint = transform.position;
        speed = projectileSO.speed;
        distance = (target - initPoint).magnitude;
        totalDuration = distance / speed;
        durationSoFar = 0;
    }

    void Update() {
        Vector3 p1 = ((target - initPoint) / 2f) + (Vector2.Perpendicular(target - initPoint) * 3f);
        float t = durationSoFar / totalDuration;
        transform.position = CalculateQuadraticBezierPoint(t, initPoint, p1, target);
        durationSoFar += Time.deltaTime;

        if (t >= 1)
            Destroy(gameObject);
    }

    private Vector3 CalculateQuadraticBezierPoint(float t, Vector3 p0, Vector3 p1, Vector3 p2) {

        //B(t) = (1-t)^2P0 + 2(t-1)tP1 + t^2P2
        float u = 1 - t;
        float tt = t * t;
        float uu = u * u;

        return uu * p0 + 2 * u * t * p1 + tt * p2;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Grandma") {
            Destroy(gameObject);
        }
    }
}
