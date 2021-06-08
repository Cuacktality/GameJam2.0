using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    private Rigidbody2D myRig;
    public float speed;
    public float jump;
    private bool saltar;
    private float horizontal;
    private SpriteRenderer flip;
    private Animator anim;
    private bool resetearSalto;

    public string scorestring = "Score: ";
    [SerializeField] TMP_Text textScore;
    private int score;

    void Start () {
        myRig = GetComponent<Rigidbody2D> ();
        flip = GetComponent<SpriteRenderer> ();
        anim = GetComponent<Animator> ();
    }

    void Update () {
        myRig.velocity = new Vector2 (horizontal * speed, myRig.velocity.y);
        horizontal = Input.GetAxis ("Horizontal");
        Mover ();
        Saltar ();
        Scoretext ();

    }
    void Scoretext () {
        if (textScore != null) {
            textScore.text = scorestring + score.ToString ();
        }

    }
    private void Mover () {

        if (horizontal != 0) {
            anim.SetBool ("Mover", true);
        } else {
            anim.SetBool ("Mover", false);
        }
        if (horizontal > 0) {
            flip.flipX = false;

        }
        if (horizontal < 0) {
            flip.flipX = true;

        }

    }
    void Saltar () {
        if (Input.GetButtonDown ("Jump") && saltar == true) {
            myRig.AddForce (Vector2.up * jump, ForceMode2D.Impulse);
            anim.SetBool ("Saltar", true);
        } else {
            anim.SetBool ("Saltar", false);
        }
    }
    private void OnCollisionEnter2D (Collision2D other) {
        if (other.gameObject.tag == "Piso") {
            saltar = true;
        }

    }
    private void OnCollisionExit2D (Collision2D other) {
        if (other.gameObject.tag == "Piso") {
            saltar = false;
        }
    }
    private void OnTriggerEnter2D (Collider2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            speed = 0;
            jump = 0;
            anim.SetTrigger ("Morir");
            Destroy (this.gameObject, 1.4f);

        }
        if (collision.gameObject.tag == "Items") {
            score++;
        }
    }

}