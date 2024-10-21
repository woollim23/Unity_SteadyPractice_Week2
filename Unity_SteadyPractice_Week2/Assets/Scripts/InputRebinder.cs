using System.Buffers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputRebinder : MonoBehaviour
{
    public InputActionAsset actionAsset;
    private InputAction spaceAction;
    private InputAction escapeAction;

    void Start()
    {
        // (�Ϸ�) [�������� 1] actionAsset���� Space �׼��� ã�� Ȱ��ȭ�մϴ�.
        spaceAction = new InputAction(binding: "<Keyboard>/space");
    }

    // (�Ϸ�) [�������� 2] ContextMenu ��Ʈ����Ʈ�� Ȱ���ؼ� �ν�����â���� ������ �� �ֵ��� ��

    void OnEnable()
    {
        // Esc Ű�� ���� �׼� ����
        escapeAction = new InputAction(binding: "<Keyboard>/escape");

        // Esc Ű �Է� �̺�Ʈ ���
        escapeAction.performed += OnEscapePressed;

        // �׼� Ȱ��ȭ
        escapeAction.Enable();
    }

    private void OnEscapePressed(InputAction.CallbackContext context)
    {
        // Esc Ű ������ �� ����
        RebindSpaceToEscape();
    }

    public void RebindSpaceToEscape()
    {
        if (spaceAction == null)
            return;
        actionAsset.FindAction("Sapce").ApplyBindingOverride("<Keyboard>/escape");

        Debug.Log("Done!");
    }

    void OnDestroy()
    {
        // �׼��� ��Ȱ��ȭ�մϴ�.
        spaceAction?.Disable();
    }
}
