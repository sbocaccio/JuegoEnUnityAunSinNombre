using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField]
    private Transform target;

     
    // Start is called before the first frame update
    void Start()
    {
         target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
