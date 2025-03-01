using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Switcher : MonoBehaviour
{
    [SerializeField] Button _button;
    [SerializeField] string _sceneName;

    private void OnEnable() {
        _button.onClick.AddListener(() => Switch());
    }

    private void Switch() {
        SceneManager.LoadScene(_sceneName);
    }

    private void OnDisable() {
        _button.onClick.RemoveAllListeners();
    }
}
