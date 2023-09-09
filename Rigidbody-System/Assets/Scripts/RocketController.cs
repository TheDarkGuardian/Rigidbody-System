using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Vector3 hedefNokta; // Hedef noktanın koordinatları
    public float yukselmeHizi = 10.0f; // Yukarı hareket hızı
    public float alcalmaHizi = 5.0f; // Aşağı hareket hızı
    public float roketHiz = 10.0f;

    private Rigidbody roketRigidbody;

    void Start()
    {
        roketRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Roketin hedefe doğru hareket etmesi
        Vector3 roketYonu = (hedefNokta - roketRigidbody.position).normalized;

        // Yukarı veya aşağı yönde kuvvet uygula
        float yukseklikFarki = hedefNokta.y - roketRigidbody.position.y;
        Vector3 yukseklikYonu = Vector3.up;

        if (yukseklikFarki < 0)
        {
            yukseklikYonu = Vector3.down;
        }

        // Yukarı veya aşağı yönde kuvveti hesapla
        float yukseklikDegisim = Mathf.Abs(yukseklikFarki);
        float yukseklikHizi = yukseklikFarki > 0 ? yukselmeHizi : alcalmaHizi;
        Vector3 yukseklikHareketi = yukseklikYonu * yukseklikHizi * yukseklikDegisim;

        // Roketin yatay hareketini uygula
        roketRigidbody.velocity = roketYonu * roketHiz;

        // Roketin yükseklik değişimini uygula (yükselme veya alçalma)
        roketRigidbody.AddForce(yukseklikHareketi, ForceMode.Acceleration);
    }
}
