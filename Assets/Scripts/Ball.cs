using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [HideInInspector] public Rigidbody2D rb;
    [HideInInspector] public CircleCollider2D col;
    private GameObject newBall;
    private bool isGrounded = false;

    [HideInInspector] public Vector3 pos { get { return transform.position; } }
    private Vector2 initialPosition = new Vector2(-1.6128f, -2.1372f);

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<CircleCollider2D>();
    }

    public void Push (Vector2 force)
    {
        if (rb != null && !rb.isKinematic)
        {
            rb.AddForce(force, ForceMode2D.Impulse);
            Debug.Log("Force applied to Rigidbody: " + force);
        }

        //rb.AddForce(force, ForceMode2D.Impulse);

        //Debug.Log("Funciona el ball.push");
    }

    public void ActivateRb()
    {
        if(rb != null)
        {
            rb.isKinematic = false;
            Debug.Log("Rigidbody activated");
        }
        else
        {
            Debug.Log("Rigidbody is null on this object");
            return;
        }
        
    }

    public void DesactivateRb()
    {
        rb.velocity = Vector3.zero;
        rb.angularVelocity = 0f;
        rb.isKinematic = true;
    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.tag == "Vaso")
    //    {
    //        Debug.Log("SALE");
    //        //AddScore();
    //        //Destroy(gameObject, 0.1f);


    //       //newBall = Instantiate(gameObject, initialPosition, transform.rotation);







    //        //if (newBall == null)
    //        //{
    //        //    Debug.LogError("New ball instantiation failed.");
    //        //    return;
    //        //}


    //        // AQUIIIIIIIIIIII CORTE A OPCION SALIR NUEVA BOLA



    //        //Debug.Log("New ball instantiated at position: " + initialPosition);
    //        //Ball ballscript = newBall.GetComponent<Ball>();

    //        //if (ballscript != null)
    //        //{
    //        //    Debug.LogError("New ball's Ball script found.");
    //        //    ballscript.ActivateRb();
    //        //}
    //        //else
    //        //{
    //        //    Debug.LogError("Ball component is missing on the newly instantiated ball.");
    //        //}

    //        //Destroy(gameObject, 0.1f);
    //    }

        
        


    //}
}
