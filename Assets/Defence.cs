using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defence : MonoBehaviour
{


    [SerializeField]
    private GameObject playerObject;
    bool DefenseMode = false;
    int defence_size = 0;
    Player player_script;
    Movimiento player_scale;

    [SerializeField]
    private Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        player_script = playerObject.GetComponent<Player>();
        player_scale = playerObject.GetComponent<Movimiento>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.X))
        {
            animator.SetTrigger("Defence_activated");
            DefenseMode = true;
            defence_size = player_scale.characterSpriteSize();
            // Debug.Log("Apreto X");
            animator.ResetTrigger("Defence_desactivated");
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            animator.ResetTrigger("Defence_activated");
            animator.SetTrigger("Defence_desactivated");
            DefenseMode = false;
            defence_size = 0;
           // Debug.Log("No apreto X");
        }
        //Defence_activated
    }
    public bool defenseActivated(){
        return DefenseMode;
    }
    public int defenseSize()
    {
        return defence_size;
    }
    public void updateDefenceSize()
    {
        if (DefenseMode)
        {
            defence_size = player_scale.characterSpriteSize();
            

        }
    }

}
