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
            ActivateDefense();
        }
        if (Input.GetKeyUp(KeyCode.X))
        {
            DesActivateDefense();
        }
    }

    void ActivateDefense()
    {
        animator.SetTrigger("Defence_activated");
        DefenseMode = true;
        defence_size = player_scale.characterSpriteSize();
        animator.ResetTrigger("Defence_desactivated");
    }

    void DesActivateDefense()
    {
        animator.ResetTrigger("Defence_activated");
        animator.SetTrigger("Defence_desactivated");
        Debug.Log("Saque la defenza");
        DefenseMode = false;
        defence_size = 0;
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
