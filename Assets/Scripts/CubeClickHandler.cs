using UnityEngine;

public class CubeClickHandler : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    private CubeBehaviour _cubeBehaviour;

    private void Awake()
    {
        _cubeBehaviour = GetComponent<CubeBehaviour>();
    }

    private void OnEnable()
    {
        _inputReader.CubeClicked += OnCubeClicked;
    }

    private void OnDisable()
    {
        _inputReader.CubeClicked -= OnCubeClicked;
    }

    private void OnCubeClicked(CubeBehaviour clickedCube)
    {
        if (clickedCube != _cubeBehaviour)
            return;

        _cubeBehaviour.HandleCubeClicked();
    }
}
