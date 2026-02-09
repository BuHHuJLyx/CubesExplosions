using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode(List<Rigidbody> explodableObjects)
    {
        foreach (Rigidbody explodableObject in explodableObjects)
            explodableObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
    }
}