using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPositionConstant : MonoBehaviour
{

    Vector3 inicialPosition;
    // Start is called before the first frame update
    void Start()
    {
        inicialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       // transform.position = inicialPosition;
    }
}
