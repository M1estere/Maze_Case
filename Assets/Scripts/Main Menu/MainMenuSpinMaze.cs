using UnityEngine;

public class MainMenuSpinMaze : MonoBehaviour
{
    [SerializeField] private float _rotateSpeed;

    private void Update()
    {
        float speed = _rotateSpeed * Time.deltaTime;
        transform.Rotate(speed / 2, speed, -speed, Space.World);
    }
}
