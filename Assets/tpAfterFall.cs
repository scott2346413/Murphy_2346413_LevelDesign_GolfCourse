using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tpAfterFall : MonoBehaviour
{
    GameObject[] respawnPoints;

    [SerializeField] float minimumHeight;

    // Start is called before the first frame update
    void Start()
    {
        respawnPoints = GameObject.FindGameObjectsWithTag("Respawn");
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < minimumHeight)
        {
            float closestDistance = Mathf.Infinity;
            Vector3 closestPoint = transform.position;

            foreach(GameObject point in respawnPoints)
            {
                float distance = Vector3.Distance(point.transform.position, transform.position);

                if(distance < closestDistance)
                {
                    closestDistance = distance;
                    closestPoint = point.transform.position;
                }
            }

            transform.position = closestPoint;
        }
    }
}
