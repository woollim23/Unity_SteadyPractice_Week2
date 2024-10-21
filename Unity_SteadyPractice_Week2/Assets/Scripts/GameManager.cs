using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 싱글톤
    public static GameManager Instance;
    void Awake()
    {
        // 초기화는 어웨이크에서
        Instance = this;
    }

    void Update()
    {
        
    }
}
