using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    [SerializeField] InputReader _inputReader;
    [SerializeField] Explosion _explosion;
    [SerializeField] CubeSplitter _cubeSplitter;

    private float _splitChance = 1.0f;
    private float _chanceDivider = 2.0f;

    private void OnEnable()
    {
        _inputReader.CubeClicked += HandleCubeClicked;
    }

    private void OnDisable()
    {
        _inputReader.CubeClicked -= HandleCubeClicked;
    }

    private void HandleCubeClicked()
    {
        float chance = Random.value;

        if (chance < _splitChance)
        {
            var spawnedCubes = _cubeSplitter.Split();

            if (spawnedCubes != null)
                _explosion.Explode(spawnedCubes);

            _splitChance /= _chanceDivider;
        }

        Destroy(gameObject);
    }
}