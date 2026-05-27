using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.wKey.isPressed)
        {
            this.transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (Keyboard.current.dKey.isPressed)
        {
            this.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        if (Keyboard.current.aKey.isPressed)
        {
            this.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        if (Keyboard.current.sKey.isPressed)
        {
            this.transform.position += Vector3.down * speed * Time.deltaTime;
        }

    }
}
