using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallThrower : MonoBehaviour
{
    public float throwForce = 10f;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            ThrowBall();
        }
    }

    void ThrowBall()
    {
        Debug.Log("Esto tira");
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2 ( 1, 1) * throwForce, ForceMode2D.Impulse);
    }
}
