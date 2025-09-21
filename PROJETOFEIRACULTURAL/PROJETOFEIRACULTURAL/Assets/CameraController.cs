using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float offsetX = 3f;
    public float offsetY = 1f;
    public float smoothSpeed = 0.125f;
    public float limitedUp = 2f;
    public float limitedDown = 0f;
    public float limitedLeft = 0f;
    public float limitedRight = 100f;

    private Transform player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>().transform;
        if (player == null)
        {
            Debug.LogError("play não encontrado.");
        }
    }

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = new Vector3(player.position.x + offsetX, player.position.y + offsetY, transform.position.z);


            desiredPosition.x = Mathf.Clamp(desiredPosition.x, limitedLeft, limitedRight);
            desiredPosition.y = Mathf.Clamp(desiredPosition.y, limitedDown, limitedUp);

            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}