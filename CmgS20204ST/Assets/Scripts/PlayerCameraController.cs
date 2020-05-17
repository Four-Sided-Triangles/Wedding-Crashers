using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(7f, 7f, -5f);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
