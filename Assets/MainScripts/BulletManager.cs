using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null || collision.gameObject.tag == "Finish") return;
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
