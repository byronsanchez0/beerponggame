using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class HoleTrigger : MonoBehaviour
{
    public GameObject ballPrefab;
    public Transform spawnPoint;
    private Vector2 initialPosition = new Vector2(-1.6128f, -2.1372f);
    public GameObject  vaso;
    private async void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Ball in hole");

            // Notify the GameManager that the ball is in the hole

            GameManagerScript.instance.BallInHole();
            //await Task.Delay(500);
            // Destroy the ball
            Destroy(other.gameObject);
            await Task.Delay(700);

            vaso.SetActive(false);
        }
        //if (other.gameObject.CompareTag("vaso"))
        //{
        //    Destroy(gameObject);
        //}

    }
}
