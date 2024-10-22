using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singletone<GameManager>
{
    public Action OnGameStart;
    public Action OnGameEnd;

    private void Start()
    {
        UIManager.Instance.OpenEndUI();
    }
}
