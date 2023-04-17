using UnityEngine;
using UnityEngine.SceneManagement;

namespace Globals.Utils
{
    public class SceneLoader : MonoBehaviour
    {
        public string SceneName;

        public void LoadScene() => SceneManager.LoadScene(SceneName);
        public void LoadScene(string name) => SceneManager.LoadScene(name);
    }
}
