using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        if (this.transform.position.y > 5)
        {
            if (ObjectPoolManager.Instance.pool == null)
            {
                Debug.LogError("ObjectPool is null!");
                return;
            }
            ObjectPoolManager.Instance.pool.Release(this.gameObject);
        }
        this.transform.Translate(Vector2.up * this.speed * Time.deltaTime);
    }
}
