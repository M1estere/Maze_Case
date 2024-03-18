using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public bool CanRotate { get; set; } = true;

    [SerializeField] private float _rotateSpeed = 4;

    [System.Obsolete]
    private void OnMouseDrag()
    {
        if (!CanRotate || Time.timeScale != 1) return;

        float xRot = Input.GetAxis("Mouse X") * _rotateSpeed * Mathf.Deg2Rad;
        float yRot = Input.GetAxis("Mouse Y") * _rotateSpeed * Mathf.Deg2Rad;

        transform.RotateAround(Vector3.up, -xRot);
        transform.RotateAround(Vector3.right, yRot);
    }
}
