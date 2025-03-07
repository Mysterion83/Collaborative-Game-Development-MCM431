using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class RandomNumberGenerator : MonoBehaviour
{
    public int[] SafeCode = new int[4];

    void Start()
    {
        // Generates 4 values from 0-9 into the SafeCode array
        GenerateSafeCode();
    }

    public void GenerateSafeCode()
    {
        for (int i = 0; i < SafeCode.Length; i++)
        {
            SafeCode[i] = Random.Range(0, 10);
        }
    }
}