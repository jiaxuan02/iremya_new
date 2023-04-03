using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObj : MonoBehaviour
{
    [SerializeField] Transform[] pos;
    [SerializeField] float speed;

    int nextposin;
    Transform nextPos;

    // Start is called before the first frame update
    void Start()
    {
        nextPos = pos[0];
    }

    // Update is called once per frame
    void Update()
    {
        MoveGameObject();
    }

    void MoveGameObject()
    {
        if (transform.position == nextPos.position)
        {
            nextposin += 1;
            if(nextposin >= pos.Length)
            {
                nextposin = 0;
            }
            
            nextPos = pos[nextposin];

        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPos.position, speed * Time.deltaTime);
        }
    }
}

