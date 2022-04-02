using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaMovement : MonoBehaviour
{
    public float speed;
    void Start() {

    }

    void Update() {
        transform.Translate(-transform.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Kid") {
            GameManager.GetInstance().GameOver();
        }
    }
}
