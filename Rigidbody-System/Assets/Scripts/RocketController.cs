using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Transform targetBObject;
    public float speed = 5.0f;
    public float accuracy = 0.1f;

    private Rigidbody rb;
    private bool hasReachedTarget = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (!hasReachedTarget)
        {
            Vector3 currentPosition = rb.position;

            Vector3 targetPositionB = targetBObject.position;
            Vector3 moveDirection = targetPositionB + currentPosition;

            if (moveDirection.magnitude < accuracy)
            {
                hasReachedTarget = true;
                rb.velocity = Vector3.zero;
                rb.position = targetPositionB;

                // Gerekirse burada ekstra işlemler yapabilirsiniz
            }
            else
            {
                rb.AddForce(moveDirection.normalized * speed, ForceMode.Acceleration);
            }
        }
    }
}
