using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // �̱���
    public static GameManager Instance;
    void Awake()
    {
        // �ʱ�ȭ�� �����ũ����
        Instance = this;
    }

    void Update()
    {
        
    }
}
