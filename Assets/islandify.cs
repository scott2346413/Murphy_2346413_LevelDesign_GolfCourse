using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.ProBuilder;

public class islandify : MonoBehaviour
{
    ProBuilderMesh mesh;
    Vertex[] vertices;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<ProBuilderMesh>();
        vertices = mesh.GetVertices();

        float upperHeightBound = getLargestVertexInDirection(vertices, 1);
        float lowerHeightBound = getLargestVertexInDirection(vertices, 1, true);

        Vector3 vertexAverage = new Vector3((getLargestVertexInDirection(vertices, 0) - getLargestVertexInDirection(vertices, 0, true))/ 2, 0, (getLargestVertexInDirection(vertices, 2) - getLargestVertexInDirection(vertices, 2, true)) / 2);
        List<Vector3> setVertices = new List<Vector3>();
        List<Vector3> setVerticesNewPositions = new List<Vector3>();

        int index = 0;
        foreach (Vertex vertex in vertices)
        {
            if (setVertices.Contains(vertex.position))
            {
                vertex.position = setVerticesNewPositions[setVertices.IndexOf(vertex.position)];
            }
            else
            {
                setVertices.Add(vertex.position);

                Vector3 offsetDir = vertex.position - vertexAverage;
                offsetDir.y = 0;

                float randomFactor = ((upperHeightBound - vertex.position.y) / (upperHeightBound - lowerHeightBound)) * (offsetDir.magnitude);

                offsetDir.Normalize();
                vertex.position -= offsetDir * randomFactor; // Random.Range(0, randomFactor);

                setVerticesNewPositions.Add(vertex.position);
            }

            vertices[index++] = vertex;
            
        }

        mesh.SetVertices(vertices);
        mesh.ToMesh();
    }

    float getLargestVertexInDirection(Vertex[] vertices, int dimension, bool reverse = false)
    {
        float currentMax = -Mathf.Infinity;

        foreach(Vertex vertex in vertices)
        {
            float number = getDimension(vertex.position, dimension);

            if (reverse)
            {
                number = -number;
            }

            if(number > currentMax)
            {
                currentMax = number;
            }
        }

        return currentMax;
    }

    float getDimension(Vector3 vector, int dimension)
    {
        if(dimension== 0)
        {
            return vector.x;
        }
        
        if(dimension== 1)
        {
            return vector.y;
        }
        
        if(dimension == 2)
        {
            return vector.z;
        }

        return 0;
    }
}
