using System.Collections.Generic;
using UnityEngine;

public class CubeSplitter : MonoBehaviour
{
    [SerializeField] private ColorChanger _colorChanger;

    private float _scaleDivider = 2.0f;

    private int _minCubesCount = 2;
    private int _maxCubesCount = 6;

    public List<Rigidbody> Split(Cube mainCube)
    {
        int cubesCount = Random.Range(_minCubesCount, _maxCubesCount + 1);
        List<Rigidbody> cubeClones = new List<Rigidbody>();

        for (int i = 0; i < cubesCount; i++)
        {
            Cube cubeClone = Instantiate(mainCube, mainCube.transform.position, mainCube.transform.rotation);
            cubeClone.transform.localScale = mainCube.transform.localScale / _scaleDivider;
            cubeClone.SetSplitChance(mainCube.SplitChance);
            _colorChanger.SetRandomColor(cubeClone);
            cubeClones.Add(cubeClone.GetComponent<Rigidbody>());
        }

        return cubeClones;
    }

    public void DestroyCube(Cube cube)
    {
        Destroy(cube.gameObject);
    }
}