using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    private Object[] hintMaterials;
    private List<int> hintIdx;
    private GameObject[] cubes;
    private List<int> cubeIdx;
    private int curHintIdx = 0;
    private int hintsNumberToShow = 0;

    // Start is called before the first frame update
    void Start()
    {
        hintMaterials = Resources.LoadAll("Images/Materials", typeof(Material));
        hintIdx = Enumerable.Range(0, hintMaterials.Length).ToList();
        // pre-shuffle
        ShuffleIdx(hintIdx); 
        while (hintMaterials[hintIdx[0]].name.Contains("D"))
        {
            ShuffleIdx(hintIdx);
        }
        cubes = GameObject.FindGameObjectsWithTag("Cube");
        cubeIdx = Enumerable.Range(0, cubes.Length).ToList();

        // show all cubes when starting 
        foreach (GameObject cube in cubes)
        {
            cube.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // number key control how many hints to display while triggering shuffle on hints and positions
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)
        || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4))
        {
            System.Int32.TryParse(Input.inputString, out hintsNumberToShow);
            ShowNewHints();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0) || Input.GetKeyDown(KeyCode.S)) 
        {
            foreach (GameObject cube in cubes)
            {
                cube.SetActive(false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            // restart by shuffling hints and starting from the first hint
            ShuffleIdx(hintIdx);
            while (hintMaterials[hintIdx[0]].name.Contains("D"))
            {
                ShuffleIdx(hintIdx);
            }
            curHintIdx = 0;

            ShowNewHints();
        }
    }

    void ShuffleIdx(List<int> list)
    {
        int n = list.Count;

        // Fisher–Yates shuffle
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            int temp = list[k];
            list[k] = list[n];
            list[n] = temp;
        }
    }

    void AssignAndShowHints()
    {
        // assume we always have enough hints for all the cubes
        for (int i = 0; i < hintsNumberToShow; i++)
        {
            cubes[cubeIdx[i]].GetComponent<Renderer>().material = (Material)hintMaterials[hintIdx[GetHintIdxFromCur(i)]];
        }

        for (int i = 0; i < cubes.Length; i++)
        {
            cubes[cubeIdx[i]].SetActive(!!(i < hintsNumberToShow));
        }
    }

    // rules:
    // 1. no hints with shape-and-direction combo
    // 2. total number of buttons <= 10
    bool IsDoable()
    {
        // total number of buttons need to press
        int total = 0;
        HashSet<string> shapeAndDirectionSet = new HashSet<string>();
        for (int i = 0; i < hintsNumberToShow; i++)
        {
            // three-letter name, eg CL2 represent the hint with shape X, direction <- and number 2
            string hintName = hintMaterials[hintIdx[GetHintIdxFromCur(i)]].name;

            // test if this shape-and-direction combo exist
            if (!shapeAndDirectionSet.Add(hintName.Substring(0, 2)))
            {
                return false;
            }

            // add up the total number
            int num = 0;
            System.Int32.TryParse(hintName.Substring(2), out num);
            total += num;
        }

        return total <= 10;
    }

    int GetHintIdxFromCur(int distance, bool isWindowMoved = false)
    {
        int nextHintIdx = (curHintIdx + distance) % hintIdx.Count;
        if (isWindowMoved && nextHintIdx < curHintIdx)
        {
            ShuffleIdx(hintIdx);
        }
        return nextHintIdx;
    }

    void ShowNewHints()
    {
        while (!IsDoable())
        {
            curHintIdx = GetHintIdxFromCur(1);
        }

        ShuffleIdx(cubeIdx);
        AssignAndShowHints();

        // move the hints window to the next position
        curHintIdx = GetHintIdxFromCur(hintsNumberToShow, true);
    }
}
