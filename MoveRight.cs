using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    private float speed = 10;
    private PlayerController playerControllerScript;
    private float rightBound = 150;

    // Start is called before the first frame update
    void Start() {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update() {
        if (playerControllerScript.gameOver == false) {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }

        if(transform.position.x > rightBound && gameObject.CompareTag("Obstacle")) {
                Destroy(gameObject);
            }
        }
    
}
