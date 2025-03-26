using UnityEngine;
using UnityEditor;

public class TestEditorWindow : EditorWindow
{
    private Character player;
    private UIInventory uiInventory;
    float amount = 0;
    string str = "";

    [MenuItem("Window/Test Editor")]
    public static void ShowWindow()
    {
        GetWindow<TestEditorWindow>("Test Editor");
    }

    private void OnGUI()
    {
        GUILayout.Label("�÷��̾� �׽�Ʈ ����", EditorStyles.boldLabel);
        player = (Character)EditorGUILayout.ObjectField("Player", player, typeof(Character), true);

        if (player != null)
        {
            str = EditorGUILayout.TextField("������ �̸�", str);

            if (GUILayout.Button("�̸� ����"))
            {
                player.SetName(str);
            }

            GUILayout.Space(20);

            amount = EditorGUILayout.FloatField("������", amount);

            if (GUILayout.Button("���ݷ� ����"))
            {
                player.UpAttackPower(amount);
            }

            if (GUILayout.Button("���� ����"))
            {
                player.UpDefensePower(amount);
            }

            if (GUILayout.Button("ü�� ����"))
            {
                player.UpHealth(amount);
            }

            if (GUILayout.Button("ũ��Ƽ�� ����"))
            {
                player.UpCritical(amount);
            }

            if (GUILayout.Button("��� ȹ��"))
            {
                player.GainGold((int)amount);
            }

            if (GUILayout.Button("����ġ ȹ��"))
            {
                player.GainExp((int)amount);
            }
        }

        GUILayout.Space(20);

        GUILayout.Label("�κ��丮 �׽�Ʈ ����", EditorStyles.boldLabel);
        uiInventory = (UIInventory)EditorGUILayout.ObjectField("UIInventory", uiInventory, typeof(UIInventory), true);

        if(uiInventory != null)
        {
            if (GUILayout.Button("���� ������ ȹ��"))
            {
                uiInventory.AddItem();
            }

            if (GUILayout.Button("���� ������ ������"))
            {
                uiInventory.DropItem();
            }
        }

    }
}
