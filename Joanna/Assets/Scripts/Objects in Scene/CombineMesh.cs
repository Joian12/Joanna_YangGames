using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CombineMesh : MonoBehaviour
{
    private void OnApplicationQuit() {
        MeshRenderer[] allMeshRenderer = GetComponentsInChildren<MeshRenderer>();
        for (int i = 0; i < allMeshRenderer.Length; i++)
        {
            allMeshRenderer[i].enabled = true;
        }
    }
}
