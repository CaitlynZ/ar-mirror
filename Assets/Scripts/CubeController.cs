using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private GameObject[] cubes;

    void Start()
    {
        // Store all the cubes in the scene
        cubes = GameObject.FindGameObjectsWithTag("Cube");

        // Hide all cubes in the beginning
        SetAllCubesVisibility(true);
    }

    void Update()
    {
        // Toggle visibility by input
        for (int i = 0; i < cubes.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ToggleCubeVisibility(i);
            }
        }
    }

    // Set visibility of all cubes
    void SetAllCubesVisibility(bool isVisible)
    {
        foreach (GameObject cube in cubes)
        {
            cube.SetActive(isVisible);
        }
    }

    // Toggle visibility of a cube
    void ToggleCubeVisibility(int index)
    {
        if (index >= 0 && index < cubes.Length)
        {
            cubes[index].SetActive(!cubes[index].activeSelf);
        }
    }
}
