using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject ballPrefab;

     void Start()
    {
        InvokeRepeating("Spawn", 2, 0.5f);
    }

    void Spawn() 
    {
        GameObject obj = Instantiate(ballPrefab, this.transform.position, Quaternion.identity);
        obj.transform.parent = this.transform;
    }
}
