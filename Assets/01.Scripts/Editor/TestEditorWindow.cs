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
        GUILayout.Label("플레이어 테스트 도구", EditorStyles.boldLabel);
        player = (Character)EditorGUILayout.ObjectField("Player", player, typeof(Character), true);

        if (player != null)
        {
            str = EditorGUILayout.TextField("변경할 이름", str);

            if (GUILayout.Button("이름 변경"))
            {
                player.SetName(str);
            }

            GUILayout.Space(20);

            amount = EditorGUILayout.FloatField("증가량", amount);

            if (GUILayout.Button("공격력 증가"))
            {
                player.UpAttackPower(amount);
            }

            if (GUILayout.Button("방어력 증가"))
            {
                player.UpDefensePower(amount);
            }

            if (GUILayout.Button("체력 증가"))
            {
                player.UpHealth(amount);
            }

            if (GUILayout.Button("크리티컬 증가"))
            {
                player.UpCritical(amount);
            }

            if (GUILayout.Button("골드 획득"))
            {
                player.GainGold((int)amount);
            }

            if (GUILayout.Button("경험치 획득"))
            {
                player.GainExp((int)amount);
            }
        }

        GUILayout.Space(20);

        GUILayout.Label("인벤토리 테스트 도구", EditorStyles.boldLabel);
        uiInventory = (UIInventory)EditorGUILayout.ObjectField("UIInventory", uiInventory, typeof(UIInventory), true);

        if(uiInventory != null)
        {
            if (GUILayout.Button("랜덤 아이템 획득"))
            {
                uiInventory.AddItem();
            }

            if (GUILayout.Button("랜덤 아이템 버리기"))
            {
                uiInventory.DropItem();
            }
        }

    }
}
