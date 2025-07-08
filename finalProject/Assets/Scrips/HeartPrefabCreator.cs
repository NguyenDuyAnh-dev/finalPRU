#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class HeartPrefabCreator
{
    [MenuItem("Tools/Tạo Prefab Trái Tim")]
    public static void CreateHeartPrefab()
    {
        // Tìm sprite trái tim
        Sprite heartSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Hearts.png");
        if (heartSprite == null)
        {
            Debug.LogError("Không tìm thấy sprite Assets/Hearts.png");
            return;
        }

        // Tạo GameObject mới
        GameObject heartGO = new GameObject("Heart");
        var sr = heartGO.AddComponent<SpriteRenderer>();
        sr.sprite = heartSprite;

        // Thêm Collider2D
        var collider = heartGO.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;

        // Gắn script Heart.cs
        heartGO.AddComponent<Heart>();

        // Tạo thư mục Prefabs nếu chưa có
        string prefabFolder = "Assets/Prefabs";
        if (!AssetDatabase.IsValidFolder(prefabFolder))
            AssetDatabase.CreateFolder("Assets", "Prefabs");

        // Lưu prefab
        string prefabPath = prefabFolder + "/Heart.prefab";
        PrefabUtility.SaveAsPrefabAsset(heartGO, prefabPath);

        // Xóa object tạm khỏi scene
        GameObject.DestroyImmediate(heartGO);

        Debug.Log("Đã tạo prefab trái tim tại: " + prefabPath);
    }
}
#endif 