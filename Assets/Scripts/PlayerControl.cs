using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public float upRotation;
    public float downRotation;
    CharacterController playerControl;
    public Transform playerCam;
    Vector3 vel;
    public float lookSensitivity;
    float xRotation = 0;
    public TMP_Text itemText;
    public string lookingAt = "nothing!";
    public bool hasKey = false;
    public GameObject bulletPrefab;
    List<GameObject> bulletPool = new List<GameObject>();
    public int bulletNum;
    int bulletIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
        playerControl = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        itemText.text = lookingAt;
        CreateBulletPool();


    }

    // Update is called once per frame
    void Update()
    {
        vel.z = Input.GetAxis("Vertical") * speed;
        vel.x = Input.GetAxis("Horizontal") * speed;

        vel = transform.TransformDirection(vel);
        playerControl.SimpleMove(vel);
        transform.Rotate(0, Input.GetAxis("Mouse X") * lookSensitivity, 0);
        xRotation -= Input.GetAxis("Mouse Y") * lookSensitivity;
        xRotation = Mathf.Clamp(xRotation, -upRotation, downRotation);
        playerCam.localRotation = Quaternion.Euler(xRotation, 0, 0);
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.GetComponent<Rigidbody>().velocity = 2 * transform.forward;
            GameObject currentBullet = bulletPool[bulletIndex];
            currentBullet.SetActive(true);
            currentBullet.transform.position = transform.position;
            currentBullet.GetComponent<Rigidbody>().velocity = 2 * transform.forward;
            bulletIndex++;
            if(bulletIndex >=bulletPool.Count)
            {
                bulletIndex = 0;
            }
        }
       
    }
    void CreateBulletPool()
    {
        for (int i = 0; i < bulletNum; i++)
        {
            GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            newBullet.SetActive(false);
            bulletPool.Add(newBullet);
        }
    }
}
