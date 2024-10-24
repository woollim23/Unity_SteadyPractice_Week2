using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectPool_2 : MonoBehaviour
{
    // [구현사항 2]
    // 최소 50개의 오브젝트 수 보장,
    // 부족할 경우 누적 300개까지 추가 생성,
    // 300개가 넘어갈 경우 가장 오래전에 생성된 오브젝트를 반환 후 재사용
    // TODO : Queue 사용해서 추가 생산해야 하나?
    private List<GameObject> pool;
    private const int minSize = 50;
    private const int maxSize = 300;
    [SerializeField] private GameObject bulletPrefab;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < minSize; i++)
        {
            pool.Add(CreateObject());
        }
    }

    private GameObject CreateObject()
    {
        GameObject newObject = Instantiate(bulletPrefab);
        newObject.SetActive(false); // 초기에는 비활성화
        return newObject;
    }

    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy) // 비활성화된 객체를 찾는다
            {
                obj.SetActive(true); // 활성화
                return obj;
            }
        }

        // 모든 객체가 활성화되어 있을 경우
        if (pool.Count < maxSize)
        {
            GameObject newObject = CreateObject();
            pool.Add(newObject);
            newObject.SetActive(true);
            return newObject;
        }

        // 최대 크기를 초과할 경우, 임시로 생성 후 반환
        GameObject tempObject = CreateObject();
        tempObject.SetActive(true);
        return tempObject;
    }

    public void ReleaseObject(GameObject obj)
    {
        if (pool.Contains(obj))
        {
            obj.SetActive(false); // 비활성화
        }
        else
        {
            Destroy(obj); // 풀에 포함되지 않은 객체는 파괴
        }
    }
}