using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movimiento : MonoBehaviour
{

    [SerializeField]
    private Animator animator;

    public float velocidad = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector3(movementX,movementY,0) * velocidad * Time.deltaTime);



        Vector3 characterScale = transform.localScale;
       
        
        if (movementX < 0) {
           
            animator.SetInteger("Movement_x", 1);
            
            characterScale.x = -1;
        }
        else if (movementX > 0)
        {
          
            animator.SetInteger("Movement_x", 1);
            characterScale.x = 1;
        }
        else
        {
           
            animator.SetInteger("Movement_x", 0);
        }
       
        transform.localScale = characterScale;
    }
}
