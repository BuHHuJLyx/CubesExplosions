using System.Collections.Generic;
using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private GameObject _cubePrefab;

    private float _scaleDivider = 2.0f;

    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;

    public List<Rigidbody> Split()
    {
        int cubesCount = Random.Range(_minCubesCount, _maxCubesCount);
        List<Rigidbody> cubeClones = new List<Rigidbody>();

        for (int i = 0; i < cubesCount; i++)
        {
            GameObject cubeClone = Instantiate(_cubePrefab, transform.position, transform.rotation);
            cubeClone.transform.localScale = transform.localScale / _scaleDivider;
            cubeClone.GetComponent<Renderer>().material.color = Random.ColorHSV();
            cubeClones.Add(cubeClone.GetComponent<Rigidbody>());
        }

        return cubeClones;
    }
}