using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class follow_player : MonoBehaviour {
    public GameObject character;//got to drag and drop into unity
    public GameObject Toggler_Control_inverter_camera_yview;
    private Vector3 offset;
    private Quaternion angle;
    public Transform target;
    public float turnspeed = 0.01f;
    private float lookatchange;
    public bool controlinverter = true;
    private int invertermultiplier = 1;
    public Scrollbar Scrollbar_MouseSpeed;


    // Use this for initialization
    void Start () {
        //get where it's currintly pointing to start it off before gravity or mouse movement ruins it
        offset = transform.position - character.transform.position;
        angle =  character.transform.rotation;

        
    }
	
	// Update is called once per frame
	void Update () {
        controlinverter = Toggler_Control_inverter_camera_yview.GetComponent<Toggle>().isOn;
        //inverter
        if (controlinverter) { invertermultiplier = -1; } else { invertermultiplier = 1; }

    }/// <summary>
     /// this is super duper key!!!!! you have to put the void late update in right here otherwise it fights with the update breaking everything!!!!
     /// </summary>
    void LateUpdate()
    {



        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        //transform.rotation = character.transform.rotation * angle;

        //Camera vertical rotation
        lookatchange = Input.GetAxis("Mouse Y")*Scrollbar_MouseSpeed.value*7*invertermultiplier;
        Debug.Log(transform.localRotation.x);
        if (transform.localRotation.x > .145 & lookatchange > 0) { lookatchange = 0; Debug.Log("helloworld2"); }
        
        if (transform.localRotation.x < -.1450 & lookatchange < 0) { lookatchange = 0;Debug.Log("helloworld"); }
        //look at change boolean inverter

        transform.Rotate(new Vector3(lookatchange, 0 , 0));
        //transform.position = character.transform.position + offset;
        


        //comented out this as a child
        //transform.LookAt(new Vector3(target.position.x,target.position.y+lookatchange*invertermultiplier, target.position.z));

        



    }
}
