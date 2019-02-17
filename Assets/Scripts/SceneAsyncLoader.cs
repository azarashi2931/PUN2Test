using System.Collections.Generic;
using UnityEditor;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneAsyncLoader : MonoBehaviour
{
    [SerializeField] string sceneName = default;

    AsyncOperation asyncOperation;

    void Start()
    {
        asyncOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
        asyncOperation.allowSceneActivation = false;
    }

    public void ChangeScene()
    {
        asyncOperation.allowSceneActivation = true;
    }

    private void OnValidate()
    {
        List<string> sceneNameList = EditorBuildSettings.scenes.Where(scene => scene.enabled).Select(scene => scene.path).Select(path => {
            int slash = path.LastIndexOf("/");
            int dot = path.LastIndexOf(".");
            return path.Substring(slash + 1, dot - slash - 1);
        }).ToList();

        if (!sceneNameList.Contains(sceneName))
            Debug.LogError("That Scene doese not exist.");
    }
}
