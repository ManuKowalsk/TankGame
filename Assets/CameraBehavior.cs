using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{

    public Transform tank;
    public Vector3 offset = new Vector3(0, 0, -10);


    // Start is called before the first frame update
    void Start()
    {
        
    }
    void LateUpdate()
    {
        if(tank != null)
        {
            Vector3 target = new Vector3(tank.position.x, tank.position.y, tank.position.z) + offset;
            transform.position = target;
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
