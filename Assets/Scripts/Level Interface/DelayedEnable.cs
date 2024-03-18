using UnityEngine;

public class DelayedEnable : MonoBehaviour
{
    [SerializeField] private RotateObject _rotateObject;
    [SerializeField] private Animator _animator;

    private Countdown _countdown;

    private void Start()
    {
        _countdown = FindObjectOfType<Countdown>();
        _rotateObject.CanRotate = false;

        if (LevelController.Instance.LevelHasSaves()) StartGame();
    }

    public void StartGame()
    {
        Destroy(_animator);

        _countdown.StartCountdown();
        _rotateObject.CanRotate = true;
        LevelController.Instance.LevelStarted = true;
    }
}
