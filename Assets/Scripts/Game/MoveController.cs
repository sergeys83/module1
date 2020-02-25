using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
  public  Character curCharacter;
    // Start is called before the first frame update
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    }
    private void Awake()
    {
        curCharacter.GetComponent<Character>();
    }
    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(inputRay, out hit))
        {
            Vector3 targetpos = hit.point;
            while (!curCharacter.RunTowards(targetpos, 0f))
            {
                curCharacter.SetState(curCharacter.state = Character.State.RunningToEnemy);
            }
        }
    }
}
