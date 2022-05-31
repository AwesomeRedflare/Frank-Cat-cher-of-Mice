using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector2 moveVelocity;
    private Animator anim;

    public SpeechSpawner speechSpawner;

    public GameObject mouseEffect;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput.normalized * speed;

        anim.SetFloat("Horizontal", moveInput.x);
        anim.SetFloat("Vertical", moveInput.y);
        anim.SetFloat("Magnitude", moveInput.magnitude);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Mouse"))
        {
            FindObjectOfType<AudioManager>().Play("Meow");

            Instantiate(mouseEffect, col.transform.position, Quaternion.identity);

            Destroy(col.gameObject);

            speechSpawner.SpawnBubble();

            AngerMeter.targetAngerAmount -= .2f;

            Score.scoreAmount++;
        }
    }
}
