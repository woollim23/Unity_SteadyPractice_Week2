using System.Collections.Generic;
using UnityEngine;

public class ObjectPool_1 : MonoBehaviour
{
    // [구현사항 1]
    // 최소 50개의 오브젝트 수 보장,
    // 부족할 경우 누적 300개까지 추가 생성,
    // 300개가 넘어갈 경우 임시로 생성 후 반환 시 파괴
    private List<GameObject> pool;
    private const int minSize = 50;
    private const int maxSize = 300;
    [SerializeField] private GameObject bulletPrefab;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < minSize; i++)
        {
            pool.Add(CreateObject()); // 일단은 최소 50개 생성
        }
    }

    // 오브젝트 생성 함수
    private GameObject CreateObject()
    {
        GameObject newObject = Instantiate(bulletPrefab);
        newObject.SetActive(false); // 초기에는 비활성화
        return newObject;
    }

    // 오브젝트 가져오는 함수
    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {// 풀 안에서
            if (!obj.activeInHierarchy) // 비활성화된 객체를 찾는다
            {
                obj.SetActive(true); // 활성화
                return obj; // 있으면 반환
            }
        }

        // 비활성화 객체 탐색 실패
        // 모든 객체가 활성화되어 있을 경우
        if (pool.Count < maxSize)
        {
            // 풀 안에 오브젝트가 최대 300개가 되기전까지는 추가
            GameObject newObject = CreateObject();
            pool.Add(newObject);
            newObject.SetActive(true);
            return newObject;
        }

        // 최대 크기를 초과할 경우, 임시로 생성 후 반환
        // 풀 안에는 추가하지 않음.
        GameObject tempObject = CreateObject();
        tempObject.SetActive(true);
        return tempObject;
    }

    // 오브젝트 반환 함수
    public void ReleaseObject(GameObject obj)
    {
        if (pool.Contains(obj))
        {// 풀안에 포함된 오브젝트면
            obj.SetActive(false); // 비활성화
        }
        else
        {
            // 풀 외의 것이면
            Destroy(obj); // 파괴
        }
    }
}
