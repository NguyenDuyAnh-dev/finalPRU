#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;

public class AddStarScriptToSceneObjects
{
    [MenuItem("Tools/Add Star Script, Sound & Effect To All 1_0 Objects In Man2")]
    public static void AddScriptSoundEffectToScene()
    {
        // Mở scene Man2
        string scenePath = "Assets/Scenes/Man2.unity";
        var scene = EditorSceneManager.OpenScene(scenePath, OpenSceneMode.Single);

        // Tìm file âm thanh và hiệu ứng
        AudioClip effectSound = AssetDatabase.LoadAssetAtPath<AudioClip>("Assets/music/mp3 - 320k/NhặtSaoSound.wav");
        GameObject effectPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/StarCollectEffect.prefab");

        int count = 0;
        foreach (GameObject obj in GameObject.FindObjectsOfType<GameObject>())
        {
            if (obj.name.StartsWith("1_0"))
            {
                Star star = obj.GetComponent<Star>();
                if (star == null)
                    star = obj.AddComponent<Star>();
                star.collectSound = effectSound;
                star.collectEffect = effectPrefab;
                count++;
                EditorUtility.SetDirty(obj);
            }
        }
        EditorSceneManager.SaveScene(scene);
        Debug.Log($"Đã gắn script Star, âm thanh và hiệu ứng cho {count} object 1_0 trong scene Man2!");
    }
}
#endif 