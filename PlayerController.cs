using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Rigidbody playerRb;
    private float jumpForce = 15.0f;
    public float gravityModifier = 1.0f;
    public bool isOnGround = true;
    public bool gameOver = false;
    private Animator playerAnim;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;

    // Start is called before the first frame update
    void Start() {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver) {
            dirtParticle.Stop();
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
            playerAnim.SetTrigger("Jump_trig");
            playerAudio.PlayOneShot(jumpSound, 1.5f);
        }
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isOnGround = true;
            dirtParticle.Play();
        } else if (collision.gameObject.CompareTag("Obstacle")) {
            dirtParticle.Stop();
            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}
