using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class testForTPAreas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TeleportationArea[] teleportationAreas = FindObjectsOfType<TeleportationArea>();
        Debug.Log(teleportationAreas.Length + "TP Areas");

        foreach(TeleportationArea area in teleportationAreas)
        {
            Debug.Log(area.name);
        }

        Mesh[] meshes = FindObjectsOfType<Mesh>();
        List<Mesh> meshesWithoutTPArea = new List<Mesh>();

        foreach(Mesh mesh in meshes)
        {
            if (mesh.GetComponent<TeleportationArea>() == null)
            {
                meshesWithoutTPArea.Add(mesh);
                Debug.Log(mesh.name);
            }
        }

        Debug.Log(meshesWithoutTPArea.Count);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
