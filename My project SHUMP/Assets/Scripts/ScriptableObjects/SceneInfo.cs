using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistence")]
public class SceneInfo : ScriptableObject
{
    public string sceneName;
    public bool isNextScene = true;

    [SerializeField]
    public SceneInfo sceneInfo;

    void OnTriggerEnter2D(Collider2D player)
    {
        sceneInfo.isNextScene = isNextScene;
        SceneManager.LoadScene(sceneName);
    }
}
