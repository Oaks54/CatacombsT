using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerTransform;

    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, transform.position.z);
    }
}
