using UnityEngine;

public class Follow_Camera : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 offset = new Vector3 (0, 2, -10);
    [SerializeField]
    private float smoothTime = 0.25f;

    Vector3 currentVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        // Camera follows the target smooth
        transform.position = Vector3.SmoothDamp(
            transform.position,
            target.position + offset,
            ref currentVelocity,
            smoothTime
            );
    }
}
