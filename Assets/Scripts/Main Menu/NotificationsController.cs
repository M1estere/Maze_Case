using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NotificationsController : MonoBehaviour
{
    [SerializeField] private GameObject _notificationBlock;
    [Space(5)]

    [SerializeField] private Button _resetLevelButton;
    [SerializeField] private Button _continueLevelButton;

    public void DisplayNotification(string sceneName)
    {
        _notificationBlock.SetActive(true);

        _resetLevelButton.onClick.AddListener(() => PlayWithReset(sceneName));
        _continueLevelButton.onClick.AddListener(() => ContinueLevel(sceneName));
    }

    private void PlayWithReset(string sceneName)
    {
        SaveController.Instance.DeleteAllKeys();
        SceneManager.LoadScene(sceneName);
    }

    private void ContinueLevel(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
