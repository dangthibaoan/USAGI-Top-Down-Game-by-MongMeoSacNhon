using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public Transform usagiTranf;

    // Update is called once per frame
    void Update()
    {
        // if (usagiTranf.position.x > transform.position.x){
        //     transform.position = new Vector3(usagiTranf.position.x, transform.position.y, transform.position.z);
        // }
        transform.position = usagiTranf.position;
    }
}
