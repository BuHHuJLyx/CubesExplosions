using UnityEngine;

public class Cube : MonoBehaviour
{
    private float _splitChance = 1.0f;
    private float _chanceDivider = 2.0f;

    public float SplitChance => _splitChance;

    public void SetSplitChance(float splitChance)
    {
        _splitChance = splitChance;
    }

    public bool TrySplit()
    {
        float chance = Random.value;

        if (chance < _splitChance)
        {
            _splitChance /= _chanceDivider;
            return true;
        }

        return false;
    }
}