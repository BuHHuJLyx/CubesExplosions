using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    [SerializeField] Camera _camera;

    private Ray _ray;

    public event Action<CubeBehaviour> CubeClicked;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _ray = _camera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(_ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.TryGetComponent(out CubeBehaviour cube))
                {
                    CubeClicked?.Invoke(cube);
                }
            }
        }
    }
}