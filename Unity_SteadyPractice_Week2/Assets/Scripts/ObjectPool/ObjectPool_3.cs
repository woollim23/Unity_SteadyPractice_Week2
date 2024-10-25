using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class ObjectPool_3 : MonoBehaviour
{
    // [�������� 3]
    // ������Ʈ�� �̸� �������� �ʰ�
    // ������ ��� ���� 100������ �߰� ����,
    // 100���� �Ѿ ��� �ӽ÷� ���� �� ��ȯ �� �ı�
    private List<GameObject> pool;
    private const int maxSize = 100;

    [SerializeField] private GameObject bulletPrefab;

    void Awake()
    {
        pool = new List<GameObject>();
    }

    private GameObject CreateObject()
    {
        GameObject newObject = Instantiate(bulletPrefab);
        newObject.SetActive(false); // �ʱ⿡�� ��Ȱ��ȭ
        return newObject;
    }

    public GameObject GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.activeInHierarchy) // ��Ȱ��ȭ�� ��ü�� ã�´�
            {
                obj.SetActive(true); // Ȱ��ȭ
                return obj;
            }
        }

        // ��� ��ü�� Ȱ��ȭ�Ǿ� ���� ���
        if (pool.Count < maxSize)
        {
            GameObject newObject = CreateObject();
            pool.Add(newObject);
            newObject.SetActive(true);
            return newObject;
        }

        GameObject tempObject = CreateObject();
        tempObject.SetActive(true);
        return tempObject;
    }

    public void ReleaseObject(GameObject obj)
    {
        if (pool.Contains(obj))
        {
            obj.SetActive(false); // ��Ȱ��ȭ
        }
        else
        {
            Destroy(obj); // Ǯ�� ���Ե��� ���� ��ü�� �ı�
        }
    }
}