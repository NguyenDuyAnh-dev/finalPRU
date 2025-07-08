#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class CreateHeartCollectEffect
{
    [MenuItem("Tools/Tạo Hiệu Ứng Ăn Heart")]
    public static void CreateEffect()
    {
        // Tạo GameObject mới cho hiệu ứng
        GameObject effect = new GameObject("HeartCollectEffect");
        var ps = effect.AddComponent<ParticleSystem>();

        // Tùy chỉnh particle
        var main = ps.main;
        main.duration = 0.6f;
        main.startLifetime = 0.4f;
        main.startSpeed = 2.5f;
        main.startSize = 0.4f;
        main.startColor = new ParticleSystem.MinMaxGradient(Color.red, Color.white);
        main.maxParticles = 50;

        var emission = ps.emission;
        emission.rateOverTime = 0;
        emission.SetBursts(new ParticleSystem.Burst[] {
            new ParticleSystem.Burst(0f, 20)
        });

        var shape = ps.shape;
        shape.shapeType = ParticleSystemShapeType.Cone;
        shape.angle = 25;
        shape.radius = 0.1f;

        // Lưu prefab
        if (!AssetDatabase.IsValidFolder("Assets/Prefabs"))
            AssetDatabase.CreateFolder("Assets", "Prefabs");
        PrefabUtility.SaveAsPrefabAsset(effect, "Assets/Prefabs/HeartCollectEffect.prefab");
        GameObject.DestroyImmediate(effect);

        Debug.Log("Đã tạo hiệu ứng HeartCollectEffect tại Assets/Prefabs/HeartCollectEffect.prefab");
    }
}
#endif 