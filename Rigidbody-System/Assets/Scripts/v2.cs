using UnityEngine;

public class v2 : MonoBehaviour
{
    public GameObject top; // Atılacak top nesnesi
    public GameObject kutu; // Hedef kutu nesnesi
    public float atisGucu = 10.0f; // Atış gücü
    public float yukseklik = 5.0f; // Atış yüksekliği

    private bool topAtildi = false;

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !topAtildi)
        {
            AtisYap();
        }
    }

    void AtisYap()
    {
        // Topu fırlat
        Rigidbody topRigidbody = top.GetComponent<Rigidbody>();
        topRigidbody.isKinematic = false;
        topRigidbody.AddForce(Vector3.up * atisGucu, ForceMode.Impulse);

        // Topun yüksekliği ayarla
        Vector3 topPosition = top.transform.position;
        topPosition.y = yukseklik;
        top.transform.position = topPosition;

        topAtildi = true;
    }

    void LateUpdate()
    {
        if (topAtildi)
        {
            // Top ve kutu arasındaki mesafeyi kontrol et
            Vector3 topPozisyon = top.transform.position;
            Vector3 kutuPozisyon = kutu.transform.position;

            if (Mathf.Abs(topPozisyon.x - kutuPozisyon.x) < 0.1f && Mathf.Abs(topPozisyon.z - kutuPozisyon.z) < 0.1f)
            {
                // Top kutunun tam ortasına geldi
                Debug.Log("Tebrikler! Top kutunun tam ortasına geldi.");
                topAtildi = false;
            }
        }
    }
}
