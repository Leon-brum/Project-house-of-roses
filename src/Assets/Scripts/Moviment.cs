using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    private float horizontalInput;
    private Rigidbody2D rb;

    [SerializeField] private int velocidade =  5;
    [SerializeField] private Transform jumpVerify;
    [SerializeField] private LayerMask jumpLayer;
    private bool inFloor;
    private Animator animator;

    private int movendoHash = Animator.StringToHash("movendo");
    private int pulandoHash = Animator.StringToHash("pulando");

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D> ();
        animator = GetComponent<Animator> ();
    }
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space) && inFloor)
        {
            rb.AddForce(Vector2.up * 600);
        }

        inFloor = Physics2D.OverlapCircle(jumpVerify.position, 0.2f, jumpLayer);
        animator.SetBool(movendoHash, horizontalInput != 0);
        animator.SetBool(pulandoHash, !inFloor);
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * 5, rb.velocity.y);
    }
}
