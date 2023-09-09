using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Vector3 hedefNokta; // Hedef noktanın koordinatları
    public float roketHiz = 10.0f; // Roketin hızı

    private Rigidbody roketRigidbody;

    void Start()
    {
        roketRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Roketin hedefe doğru hareket etmesi
        Vector3 roketYonu = (hedefNokta - roketRigidbody.position).normalized;
        roketRigidbody.velocity = roketYonu * roketHiz;
    }
}
