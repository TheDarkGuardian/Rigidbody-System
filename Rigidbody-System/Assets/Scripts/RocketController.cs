using UnityEngine;

public class RocketController : MonoBehaviour
{
    public Vector3 hedefNokta; // Hedef noktanın koordinatları
    public float roketHiz = 10.0f; // Roketin hızı
    public float yukselmeHizi = 5.0f; // Yükselme hızı
    public float alcalmaHizi = 2.0f; // Alçalma hızı

    private Rigidbody roketRigidbody;

    void Start()
    {
        roketRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Roketin hedefe doğru hareket etmesi
        Vector3 roketYonu = (hedefNokta - transform.position).normalized;
        roketRigidbody.velocity = roketYonu * roketHiz;

        // Roketin yükseklik değişimini hesapla ve uygula
        float yukseklikFarki = hedefNokta.y - roketRigidbody.position.y;

/*if (yukseklikFarki > 0)
{
    // Yukarı yönde bir kuvvet uygula
    roketRigidbody.AddForce(Vector3.up * yukselmeHizi);
}
else if (yukseklikFarki < 0)
{
    // Aşağı yönde bir kuvvet uygula
    roketRigidbody.AddForce(Vector3.down * alcalmaHizi);
}*/

        // Yükseklik değişimini uygula (yükselme veya alçalma)
        /*float yukseklikDegisim = Mathf.Abs(yukseklikFarki);
        float yukseklikHizi = yukseklikFarki > 0 ? yukselmeHizi : alcalmaHizi;
        Vector3 yukseklikHareketi = yukseklikYonu * yukseklikHizi * yukseklikDegisim;
        roketRigidbody.velocity += yukseklikHareketi;*/
    }
}
