#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class StarPrefabCreator
{
    [MenuItem("Tools/Tạo Prefab Coin từ hình 1.png")]
    public static void CreateCoinPrefabFrom1Png()
    {
        // Đường dẫn sprite coin (hình 1)
        Sprite coinSprite = AssetDatabase.LoadAssetAtPath<Sprite>("Assets/Scenes/image/3 Objects/Xu Coin/1.png");
        if (coinSprite == null)
        {
            Debug.LogError("Không tìm thấy sprite Assets/Scenes/image/3 Objects/Xu Coin/1.png. Hãy kiểm tra lại đường dẫn hoặc import sprite coin vào đúng thư mục.");
            return;
        }

        // Tạo GameObject mới
        GameObject coinGO = new GameObject("Coin");
        var sr = coinGO.AddComponent<SpriteRenderer>();
        sr.sprite = coinSprite;

        // Thêm Collider2D
        var collider = coinGO.AddComponent<CircleCollider2D>();
        collider.isTrigger = true;

        // Gắn script Star.cs (dùng lại logic ăn coin được điểm)
        var starScript = coinGO.AddComponent<Star>();
        // Để trống trường collectSound và collectEffect để bạn tự kéo vào Inspector

        // Tạo thư mục Prefabs nếu chưa có
        string prefabFolder = "Assets/Prefabs";
        if (!AssetDatabase.IsValidFolder(prefabFolder))
            AssetDatabase.CreateFolder("Assets", "Prefabs");

        // Lưu prefab
        string prefabPath = prefabFolder + "/Coin.prefab";
        PrefabUtility.SaveAsPrefabAsset(coinGO, prefabPath);

        // Xóa object tạm khỏi scene
        GameObject.DestroyImmediate(coinGO);

        Debug.Log("Đã tạo prefab coin tại: " + prefabPath);
    }
}
#endif 