using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destinate : MonoBehaviour
{
    [SerializeField] private Transform destination;
 
    // Update is called once per frame
    public Transform GetDestination(){
        return destination;
    }
}
