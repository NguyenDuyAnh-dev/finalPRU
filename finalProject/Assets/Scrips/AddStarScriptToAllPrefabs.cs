#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class AddStarScriptToAllPrefabs
{
    [MenuItem("Tools/Add Star Script, Sound & Effect To All 1_0 Prefabs")]
    public static void AddScriptSoundEffect()
    {
        // Đường dẫn thư mục chứa các prefab coin/star
        string searchFolder = "Assets/Scenes/image/3 Objects/Xu Coin";
        // Tìm tất cả prefab có tên bắt đầu bằng 1_0
        string[] guids = AssetDatabase.FindAssets("1_0 t:Prefab", new[] { searchFolder });

        // Sử dụng đúng đường dẫn file NhặtSaoSound.wav
        AudioClip effectSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/music/mp3 - 320k/NhặtSaoSound.wav");
        if (effectSound == null)
        {
            Debug.LogError("Không tìm thấy file âm thanh NhặtSaoSound.wav ở Assets/music/mp3 - 320k. Hãy kiểm tra lại tên file và đường dẫn!");
            return;
        }

        // Tìm hoặc tạo hiệu ứng particle StarCollectEffect
        GameObject effectPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/StarCollectEffect.prefab");
        if (effectPrefab == null)
        {
            // Nếu chưa có, tạo hiệu ứng đơn giản
            GameObject effect = new GameObject("StarCollectEffect");
            var ps = effect.AddComponent<ParticleSystem>();
            var main = ps.main;
            main.duration = 0.5f;
            main.startLifetime = 0.4f;
            main.startSpeed = 3f;
            main.startSize = 0.3f;
            main.startColor = Color.yellow;
            var emission = ps.emission;
            emission.rateOverTime = 40;
            var shape = ps.shape;
            shape.shapeType = ParticleSystemShapeType.Cone;
            // Lưu prefab
            if (!AssetDatabase.IsValidFolder("Assets/Prefabs"))
                AssetDatabase.CreateFolder("Assets", "Prefabs");
            PrefabUtility.SaveAsPrefabAsset(effect, "Assets/Prefabs/StarCollectEffect.prefab");
            effectPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/StarCollectEffect.prefab");
            GameObject.DestroyImmediate(effect);
        }
        foreach (string guid in guids)
        {
            string path = AssetDatabase.GUIDToAssetPath(guid);
            GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
            if (prefab != null)
            {
                // Mở prefab để chỉnh sửa
                GameObject instance = PrefabUtility.LoadPrefabContents(path);
                Star star = instance.GetComponent<Star>();
                if (star == null)
                {
                    star = instance.AddComponent<Star>();
                }
                // Gán lại chắc chắn
                SerializedObject so = new SerializedObject(star);
                so.FindProperty("collectSound").objectReferenceValue = effectSound;
                so.FindProperty("collectEffect").objectReferenceValue = effectPrefab;
                so.ApplyModifiedProperties();

                // Lưu lại prefab
                PrefabUtility.SaveAsPrefabAsset(instance, path);
                PrefabUtility.UnloadPrefabContents(instance);
            }
        }
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
        Debug.Log("Đã gắn script Star, âm thanh NhặtSaoSound.wav và hiệu ứng StarCollectEffect cho tất cả prefab 1_0 trong Xu Coin!");
    }
}
#endif 