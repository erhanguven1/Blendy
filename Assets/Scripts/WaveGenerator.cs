using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization.Advanced;
using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    public static WaveGenerator Instance;

    public MeshRenderer meshRend;
    public MeshFilter meshFilter;

    public Vector2Int size;
    public float resolutionX;
    public float gap;
    public float angle;

    public float speed;

    private List<Vector3> oldVerts = new List<Vector3>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        meshRend = GetComponent<MeshRenderer>();
        meshFilter = GetComponent<MeshFilter>();

        GenerateMesh();
    }

    private void Update()
    {
    }

    private void GenerateMesh()
    {
        Mesh m = new Mesh();
        var verts = m.vertices.ToList();
        var tris = m.triangles.ToList();


        for (int i = 0; i < size.y; i++)
        {
            for (int j = -size.x/2; j < size.x/2+1; j++)
            {
                verts.Add(new Vector3(j * resolutionX, i * gap, 0));
                oldVerts.Add(new Vector3(j* resolutionX, i * gap, 0));
            }
        }

        m.vertices = verts.ToArray();

        for (int i = 0; i < size.x - 1; i++)
        {
            tris.Add(i);
            tris.Add(i + 1);
            tris.Add(i + size.x);
            tris.Add(i + size.x);
            tris.Add(i + 1);
            tris.Add(i + size.x + 1);
        }

        m.triangles = tris.ToArray();
        meshFilter.mesh = m;

        StartCoroutine("DeformMesh");

    }

    IEnumerator DeformMesh()
    {
        var v = meshFilter.mesh.vertices;

        for (int i = meshFilter.mesh.vertexCount/2; i < meshFilter.mesh.vertexCount; i++)
        {
            angle += 45;
            float angleRad = (angle) * Mathf.Deg2Rad;
            v[i] = oldVerts[i];
            v[i] += Vector3.up * Mathf.Sin(angleRad) * .05f * speed;
        }
        yield return new WaitForSeconds(Time.deltaTime);

        meshFilter.mesh.vertices = v;
        meshFilter.mesh.RecalculateBounds();
        meshFilter.mesh.RecalculateNormals();

        StartCoroutine("DeformMesh");
    }
}
