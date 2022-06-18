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
        float moveAxis = Input.GetAxis("Vertical");//-1 +1 yumuþak þekilde döndürür. GetAxisRow -1 +1 direk döndürür.Ýleri Geri
        float rotAxis = Input.GetAxis("Horizontal");//döndürmek için rotation axis 


        transform.position += transform.forward * moveAxis * moveSpeed * Time.deltaTime ;
        transform.rotation *= Quaternion.Euler(transform.up * rotAxis * rotSpeed * Time.deltaTime);
    }
}
