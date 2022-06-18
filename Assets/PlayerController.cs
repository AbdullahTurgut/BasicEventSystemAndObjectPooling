using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float moveSpeed = 5f;
    float rotSpeed=240f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float moveAxis = Input.GetAxis("Vertical");//-1 +1 yumu�ak �ekilde d�nd�r�r. GetAxisRow -1 +1 direk d�nd�r�r.�leri Geri
        float rotAxis = Input.GetAxis("Horizontal");//d�nd�rmek i�in rotation axis 


        transform.position += transform.forward * moveAxis * moveSpeed * Time.deltaTime ;
        transform.rotation *= Quaternion.Euler(transform.up * rotAxis * rotSpeed * Time.deltaTime);
    }
}
