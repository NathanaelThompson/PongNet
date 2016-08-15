using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Controller : NetworkBehaviour {

    float Xcoord; // X coordinate
    float Zcoord; // Z coordinate
    GameObject mainCamera;

    // Use this for initialization
    void Start()
    {
        if (isLocalPlayer)
        {
            mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
        {
            return;
        }

        Xcoord += Input.GetAxis("Horizontal") * Time.deltaTime;
        Zcoord += Input.GetAxis("Vertical") * Time.deltaTime;

        transform.Translate(Xcoord, 0, Zcoord);
        mainCamera.transform.Translate(Xcoord, 0, Zcoord);
        mainCamera.transform.LookAt(gameObject.transform);
    }
    public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
