using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : Singletone<ObjectPoolManager>
{
    [SerializeField] private GameObject bulletPrefab;

    private const int minSize = 50;
    private const int maxSize = 300;

    List<GameObject> tempObject;
    public IObjectPool<GameObject> pool { get; private set; }

    void Awake()
    {
        init();
    }

    private void init()
    {
        pool = new ObjectPool<GameObject>(CreateObject, GetObject, ReleaseObject,
        DestroyPool, true, minSize, maxSize);
        for (int i = 0; i < minSize; i++)
        {
            GameObject obj = CreateObject();

            if (pool != null)
                pool.Release(obj);
        }

        // maxSize 이상의 오브젝트를 관리할 임시 리스트
        tempObject = new List<GameObject>();
    }

    // 오브젝트 생성 함수
    private GameObject CreateObject()
    {
        GameObject newObject = Instantiate(bulletPrefab);
        newObject.SetActive(false); // 초기에는 비활성화
        return newObject;
    }
    // 사용
    private void GetObject(GameObject obj)
    {
        obj.SetActive(true);
    }

    // 반환
    private void ReleaseObject(GameObject obj)
    {
        obj.SetActive(false);
        if (pool.CountInactive >= maxSize)
        {
            // 풀에 공간이 없으면 임시 오브젝트 리스트에 추가
            tempObject.Add(obj);
        }
    }

    // 삭제
    private void DestroyPool(GameObject obj)
    {
        Destroy(obj);
        if (tempObject.Contains(obj))
            tempObject.Remove(obj);

    }
}