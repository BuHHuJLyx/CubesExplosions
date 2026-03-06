using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float _explosionForce;
    [SerializeField] private float _explosionRadius;

    public void Explode(List<Rigidbody> explodableObjects, Vector3 explosionCenter)
    {
        foreach (Rigidbody explodableObject in explodableObjects)
            explodableObject.AddExplosionForce(_explosionForce, explosionCenter, _explosionRadius);
    }

    public void ExplodeAround(Vector3 explosionCenter, float cubeSize)
    {
        float multiplier = 1 / cubeSize;

        float finalForce = _explosionForce * multiplier;
        float finalRadius = _explosionRadius * multiplier;

        foreach (Rigidbody explodableObject in GetExplodableObjects(explosionCenter, finalRadius))
            explodableObject.AddExplosionForce(finalForce, explosionCenter, finalRadius);
    }

    private List<Rigidbody> GetExplodableObjects(Vector3 explosionCenter, float explosionRadius)
    {
        Collider[] hits = Physics.OverlapSphere(explosionCenter, explosionRadius);

        List<Rigidbody> cubes = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                cubes.Add(hit.attachedRigidbody);

        return cubes;
    }
}