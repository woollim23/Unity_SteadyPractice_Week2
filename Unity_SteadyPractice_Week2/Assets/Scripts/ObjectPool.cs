using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<GameObject> pool;
    private const int minSize = 50;
    private const int maxSize = 300;

    void Awake()
    {
        pool = new List<GameObject>();
        for (int i = 0; i < minSize; i++)
        {
            //pool.Add(CreateObject());
        }
    }
    /*
    private GameObject CreateObject()
    {
        // [요구스펙 1] Create Object
        // 최소 50개의 오브젝트 수 보장,
        // 부족할 경우 누적 300개까지 추가 생성,
        // 300개가 넘어갈 경우 임시로 생성 후 반환 시 파괴
    }

    public GameObject GetObject()
    {
        // [요구스펙 2] Get Object
        // 최소 50개의 오브젝트 수 보장,
        // 부족할 경우 누적 300개까지 추가 생성,
        // 300개가 넘어갈 경우 가장 오래전에 생성된 오브젝트를 반환 후 재사용
    }
    */
    public void ReleaseObject(GameObject obj)
    {
        // [요구스펙 3] Release Object
        // 오브젝트를 미리 생성하지 않고 부족할 경우 누적 100개까지 추가 생성,
        // 100개가 넘어갈 경우 임시로 생성 후 반환 시 파괴
    }
    // [구현사항 4] 이 중 하나를 UnityEngine.Pool을 활용하여 구현
}
