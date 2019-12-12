using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Threading;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    public CharacterController controller;
    public UIreference UI;
    public GameObject canvasObject;
    float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 20f;
    public Transform checkGround;
    public float checkDistance = 1f;
    public LayerMask groundMask;
    public bool paused;

    Vector3 velocity;
    bool groundCollision;

    void Start()
    {
        string filename = Application.persistentDataPath + @"\savegame.txt";
        if (File.Exists(filename))
        {
            string[] save = File.ReadAllLines(filename);
            float savetime = float.Parse(save[0]);      
            UI.timeoffset = savetime;
            int fish = save.Length > 1 ? int.Parse(save[1]) : 0;
            UI.fishAmount = fish;
            UI.UpdateFishCount();
        }
    }
    void Pause() {
       
       canvasObject.SetActive(!canvasObject.activeSelf);
       Cursor.lockState = CursorLockMode.None;
       
      

     }
    // Update is called once per frame
    void Update()
    {
         if (Input.GetButtonDown("Cancel"))
        {
        paused=!paused;
        if(paused) Pause(); 
          }
        if (Input.GetKeyDown(KeyCode.F5))
        {
            save();
        }
      if(paused==false){
        groundCollision = Physics.CheckSphere(checkGround.position, checkDistance, groundMask);

        if(groundCollision && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
         
        controller.Move(move * speed * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && groundCollision)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}

    void save()
    {
        string time = Time.time.ToString();
        string fish = UI.fishAmount.ToString();
        string[] save = { time, fish };
        File.WriteAllLines(Application.persistentDataPath + @"\savegame.txt", save);
    }
}
