using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBooks : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider2d;
    public float distance;
    bool isFalling = false;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider2d = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        Physics2D.queriesStartInColliders = false;
        if (isFalling == false)
        {
            RaycastHit2D hit = Physics.Raycast(transform.position.Vector2.down, distance);

            Debug.DrawRay(transform.position, Vector2.down * distance, Color.red);
        }

    }
}
