using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public Material[] hintMaterials;
    private List<int> hintIdx;
    private GameObject[] cubes;
    private List<int> cubeIdx;

    // Start is called before the first frame update
    void Start()
    {
        hintIdx = Enumerable.Range(0, hintMaterials.Length).ToList();

        Debug.Log(hintIdx.Count);
        cubes = GameObject.FindGameObjectsWithTag("Cube");
        cubeIdx = Enumerable.Range(0, cubes.Length).ToList();

        foreach (GameObject cube in cubes)
        {
            cube.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)
        || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            ShuffleIdx(hintIdx);
            AssignHints();

            int cubeShown = 0;
            System.Int32.TryParse(Input.inputString, out cubeShown);
            ShuffleIdx(cubeIdx);
            DisplayCubes(cubeShown);

        }
    }

    void ShuffleIdx(List<int> list)
    {
        int n = list.Count;

        // Fisher–Yates shuffle
        while (n > 1)
        {
            n--;
            Debug.Log(n);
            int k = Random.Range(0, n + 1);
            int temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    void AssignHints()
    {
        // assume we always have enough hints for all the cubes
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[i].GetComponent<Renderer>().material = hintMaterials[hintIdx[i]];
        }
    }

    void DisplayCubes(int cubeShown)
    {
        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[cubeIdx[i]].SetActive(!!(i < cubeShown));
        }
    }

}
