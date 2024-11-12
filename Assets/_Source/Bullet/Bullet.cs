using UnityEngine;

namespace Bullet
{
    public class Bullet : MonoBehaviour
    {
        public float speed = 20f;
        public float lifetime = 2f;

        private void OnEnable()
        {
            Invoke("ReturnToPool", lifetime);
        }

        private void Update()
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        private void ReturnToPool()
        {
            BulletPool bulletPool = FindAnyObjectByType<BulletPool>();
            bulletPool.ReturnObject(gameObject);
        }
    }
}
