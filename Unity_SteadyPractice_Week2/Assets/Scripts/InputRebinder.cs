using System;
using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
    public float speed = 1f;
    public Transform bulletSpawnPoint;

    public InputActionAsset actionAsset;
    private InputAction spaceAction;
    private InputAction escapeAction;

    void Start()
    {
        // (완료) [구현사항 1] actionAsset에서 Space 액션을 찾고 활성화합니다.
        spaceAction = actionAsset.FindAction("Space");

        // Space 액션 활성화
        spaceAction.Enable();
        spaceAction.performed += OnSpacePressed;

    }

    // (완료) [구현사항 2] ContextMenu 어트리뷰트를 활용해서 인스펙터창에서 적용할 수 있도록 함

    void OnEnable()
    {
        // Esc 키에 대한 액션 생성
        escapeAction = new InputAction(binding: "<Keyboard>/escape");

        // Esc 키 입력 이벤트 등록
        escapeAction.performed += OnEscapePressed;

        // 액션 활성화
        escapeAction.Enable();
    }

    public void OnSpacePressed(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("Check_Space");
        }

        var bulletGo = ObjectPoolManager.Instance.pool.Get();

        bulletGo.transform.position = this.bulletSpawnPoint.position;
    }

    private void OnEscapePressed(InputAction.CallbackContext context)
    {
        // Esc 키 눌렀을 때 실행
        RebindSpaceToEscape();
    }

    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;
        actionAsset.FindAction("Space").ApplyBindingOverride("<Keyboard>/escape");

        Debug.Log("Done!");
    }

    void OnDestroy()
    {
        // 액션을 비활성화합니다.
        spaceAction?.Disable();
        escapeAction?.Disable();
    }
}
