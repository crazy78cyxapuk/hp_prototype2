using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Mesh collisioner;
    public SkinnedMeshRenderer skinMesh;
    public MeshCollider colisiom;

    void Start()
    {
        skinMesh = GetComponent<SkinnedMeshRenderer>();
        collisioner = new Mesh();
        colisiom = GetComponent<MeshCollider>();
    }

    void Update()
    {
        skinMesh.BakeMesh(collisioner);
        colisiom.sharedMesh = collisioner;
    }
}
