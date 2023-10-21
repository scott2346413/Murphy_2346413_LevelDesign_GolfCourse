using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    [SerializeField] Transform teleportPoint;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("player"))
        {
            other.transform.position = teleportPoint.position;
        }
    }
}
