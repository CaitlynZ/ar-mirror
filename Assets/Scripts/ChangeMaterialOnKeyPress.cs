using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialOnKeyPress : MonoBehaviour
{
    public Material[] hintMaterial;

    private MeshRenderer cubeRenderer;

    void Start()
    {
        cubeRenderer = GetComponent<MeshRenderer>();
        // Initially set the cube's material
        cubeRenderer.material = hintMaterial[0];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Check for the Enter key press
        {
            int randomMaterialIndex = Random.Range(0, hintMaterial.Length);
            cubeRenderer.material = hintMaterial[randomMaterialIndex];
        }
    }
}
