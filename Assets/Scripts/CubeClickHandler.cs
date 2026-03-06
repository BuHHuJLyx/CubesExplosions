using System.Collections.Generic;
using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private Explosion _explosion;
    [SerializeField] private CubeSplitter _cubeSplitter;
    [SerializeField] private Cube _cube;

    private void Awake()
    {
        _cube = GetComponent<Cube>();
    }

    private void OnEnable()
    {
        _inputReader.CubeClicked += OnCubeClicked;
    }

    private void OnDisable()
    {
        _inputReader.CubeClicked -= OnCubeClicked;
    }

    private void OnCubeClicked(Cube clickedCube)
    {
        if (clickedCube != _cube)
            return;

        if (_cube.TrySplit())
        {
            List<Rigidbody> spawnedCubes = _cubeSplitter.Split(_cube);

            _explosion.Explode(spawnedCubes);
        }

        _cubeSplitter.DestroyCube(_cube);
    }
}