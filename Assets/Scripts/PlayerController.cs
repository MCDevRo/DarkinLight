using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 2.0f;
    public float destroyDelay = 3.0f;
    public float bulletSpeed = 3.0f;
    public GameObject bulletPrefab;
    public Transform fireBullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, 0);
        Vector3 moveDirection2 = new Vector3(0, 0, verticalInput);

        if(moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
            transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);
        }
        else if(moveDirection2 != Vector3.zero)
        {
            transform.forward = moveDirection2;
            transform.Translate(moveDirection2 * speed * Time.deltaTime, Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }
    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, fireBullet.position, fireBullet.rotation);
        bullet.transform.position = fireBullet.transform.position;
        bullet.GetComponent<Rigidbody>().AddForce(fireBullet.forward * bulletSpeed, ForceMode.Impulse);
        StartCoroutine(DestroyBulletAfterTime(bullet, destroyDelay));
    }
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
