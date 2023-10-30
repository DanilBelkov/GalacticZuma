using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInit : MonoBehaviour
{
    public GameObject Bullet;

    private float _speedBullet = 40f;
    [SerializeField]
    private float SpeedRotate = 100f; 
    [SerializeField]
    private float Offset = 100f;

    private Vector2 _rotation;

    void Start()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = Offset;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Debug.DrawRay(transform.position, mousePosition - transform.position, Color.blue);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, Offset))
        {
            transform.LookAt(hit.point);
            if (Input.GetKeyUp(KeyCode.Mouse0))
            { 
                var bullet = Instantiate(Bullet, transform.position, transform.rotation);
                bullet.GetComponent<Rigidbody>().AddForce(transform.forward * _speedBullet, ForceMode.Impulse);
                Destroy(bullet, 4f);
            }
        }
    }
}
