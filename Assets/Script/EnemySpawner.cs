using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float delay= 5; // every half second;
    public GameObject Drip;
    public GameObject player;
    public Transform spawn;
    public bool stop;

    private float startTime;

    private void Start()
    {
        StartCoroutine(SpawnTime());
    }

    /*private void Update()
    {
        Spawn();
       
        
    }  */

    IEnumerator SpawnTime()
    {
        while (!stop)
        {
            Instantiate(Drip, spawn.position, Drip.transform.rotation);
            yield return new WaitForSeconds(2.0f);
        }
    }


}