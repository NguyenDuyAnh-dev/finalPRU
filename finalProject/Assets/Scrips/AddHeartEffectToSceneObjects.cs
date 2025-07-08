#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class AddHeartEffectToSceneObjects
{
    [MenuItem("Tools/Add Heart Effect & Sound To All Heart Objects In Man1")]
    public static void AddEffectSoundToHeartInScene()
    {
        // Mở scene Man1
        string scenePath = "Assets/Scenes/Man1.unity";
        var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        // Tìm file âm thanh và hiệu ứng
        AudioClip effectSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/music/mp3 - 320k/NhặtSaoSound.wav");
        GameObject effectPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/StarCollectEffect.prefab");

        int count = 0;
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.name.Contains("Heart"))
            {
                Heart heart = obj.GetComponent<Heart>();
                if (heart != null)
                {
                    heart.healAmount = 1; // Đảm bảo chỉ heal 1 máu
                    heart.GetType().GetField("collectSound").SetValue(heart, effectSound);
                    heart.GetType().GetField("collectEffect").SetValue(heart, effectPrefab);
                    count++;
                    EditorUtility.SetDirty(obj);
                }
            }
        }
        EditorSceneManager.SaveScene(scene);
        Debug.Log($"Đã gán hiệu ứng và âm thanh cho {count} object Heart trong scene Man1!");
    }
}
#endif 