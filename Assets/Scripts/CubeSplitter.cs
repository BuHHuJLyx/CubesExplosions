using System.Collections.Generic;
using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    private float _splitChance = 1.0f;
    private float _chanceDivider = 2.0f;
    private float _scaleDivider = 2.0f;

    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;

    public List<Rigidbody> TrySplit()
    {
        float chance = Random.value;

        if (chance > _splitChance)
            return null;

        int cubesCount = Random.Range(_minCubesCount, _maxCubesCount);
        List<Rigidbody> cubeClones = new List<Rigidbody>();

        for (int i = 0; i < cubesCount; i++)
        {
            GameObject cubeClone = Instantiate(gameObject);
            cubeClone.transform.localScale = transform.localScale / _scaleDivider;
            cubeClone.GetComponent<Renderer>().material.color = Random.ColorHSV();
            cubeClones.Add(cubeClone.GetComponent<Rigidbody>());
        }

        _splitChance /= _chanceDivider;

        return cubeClones;
    }
}