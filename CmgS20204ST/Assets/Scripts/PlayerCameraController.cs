using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    public Transform player;
    private Vector3 offset = new Vector3(5.5f, 7f, -10f);

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;
    }
}
