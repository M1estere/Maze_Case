using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetupCard : MonoBehaviour
{
    [SerializeField] private Image _previewImage;
    [SerializeField] private TMPro.TMP_Text _levelTitle;
    [Space(5)]

    [SerializeField] private TMPro.TMP_Text _recordTime;
    [SerializeField] private TMPro.TMP_Text _expectedTime;
    [Space(5)]

    [SerializeField] private Button _playLevelButton;

    private NotificationsController _notificationsController;

    public void Setup(Level level, int index)
    {
        _notificationsController = FindObjectOfType<NotificationsController>();

        _previewImage.sprite = level.LevelPreview;
        _levelTitle.SetText($"level {index + 1}");

        float recordTime = level.RecordTime;
        float expectedTime = level.ExpectedTime;
        _recordTime.SetText(recordTime == 0 ? "-" : recordTime.ToString("00") + "sec");
        _expectedTime.SetText(expectedTime == 0 ? "-" : expectedTime.ToString("00") + "sec");

        _playLevelButton.onClick.AddListener(() => CheckSaves(index));
    }

    public void CheckSaves(int index)
    {
        string levelName = $"Level {index + 1}";
        if (SaveController.Instance.HasAllLevelKeys(levelName))
            _notificationsController.DisplayNotification(levelName);
        else
            SceneManager.LoadScene(levelName);
    }
}