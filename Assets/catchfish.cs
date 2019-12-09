using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class catchfish : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            var hits = Physics.RaycastAll(ray);
            foreach(var hit in hits)
            {
                Transform objectHit = hit.transform;
                fish theFish = objectHit.gameObject.GetComponent<fish>();
                if (theFish != null)
                {
                    Destroy(theFish.gameObject);
                }
            }
        }   
    }
}
