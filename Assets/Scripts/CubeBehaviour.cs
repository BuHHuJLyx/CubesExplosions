using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;
    [SerializeField] Explosion _explosion;
    [SerializeField] CubeSplitter _cubeSplitter;

    private void OnEnable()
    {
        _inputReader.MouseClicked += HandleClick;
    }

    private void OnDisable()
    {
        _inputReader.MouseClicked -= HandleClick;
    }

    private void HandleClick()
    {
        var spawnedCubes = _cubeSplitter.TrySplit();

        if (spawnedCubes != null)
            _explosion.Explode(spawnedCubes);

        Destroy(gameObject);
    }
}