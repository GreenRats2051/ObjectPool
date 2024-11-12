using UnityEngine;

public class Shooting : MonoBehaviour
{
    public BulletPool bulletPool;
    public Transform shootingPoint;

    private void Awake()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = bulletPool.TryGetFromPool();
        bullet.transform.position = shootingPoint.position;
        bullet.transform.rotation = shootingPoint.rotation;
    }
}
