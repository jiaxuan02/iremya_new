using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float frequency = 10f; // every half second;
    public GameObject Drip;
    public GameObject player;
    public Transform spawn;

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        WaitForSeconds delay = new WaitForSeconds(frequency);

        while (true)
        {
            yield return delay;

            // spawn your objects
            Instantiate(Drip, spawn.position, Quaternion.identity);
            yield return new WaitForSeconds(10);

            //spawndeletion
        }

       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(Drip);
            Destroy(player);
        }
            
    }


}