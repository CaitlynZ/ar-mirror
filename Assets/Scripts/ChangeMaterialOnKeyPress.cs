using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialOnKeyPress : MonoBehaviour
{
    public Material hint1Material;
    public Material hint3Material;

    private MeshRenderer cubeRenderer;
    private bool isHint1Material = true;

    void Start()
    {
        cubeRenderer = GetComponent<MeshRenderer>();
        // Initially set the cube's material to hint1Material
        cubeRenderer.material = hint1Material;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Check for the Enter key press
        {
            // Toggle between hint1Material and hint3Material
            if (isHint1Material)
            {
                cubeRenderer.material = hint3Material;
            }
            else
            {
                cubeRenderer.material = hint1Material;
            }
            isHint1Material = !isHint1Material;
        }
    }
}
