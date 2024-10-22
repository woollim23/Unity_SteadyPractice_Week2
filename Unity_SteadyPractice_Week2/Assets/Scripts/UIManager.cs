using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UIManager : Singletone<UIManager>
{
    private void Start()
    {
        Debug.Log(GameManager.Instance);

        GameManager.Instance.OnGameStart += OpenStartUI;
        GameManager.Instance.OnGameEnd += OpenEndUI;
    }

    public void OpenStartUI()
    {
        Debug.Log(message: "GameStart");
    }

    public void OpenEndUI()
    {
        Debug.Log(message: "GameEnd");
    }
}
