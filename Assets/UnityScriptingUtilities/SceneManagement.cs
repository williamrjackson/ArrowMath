using UnityEngine;
using UnityEngine.SceneManagement;

namespace Wrj
{       
    public class SceneManagement : MonoBehaviour
    {
        public static void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        }
    }
}
