using UnityEngine;
using System.Collections;

namespace Com.ThoughtExperimentGames.PongNet
{

    public class newController : Photon.MonoBehaviour
    {
        float Xcoord; // X coordinate
        float Zcoord; // Z coordinate
        public float height = 2;

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (photonView.isMine == false && PhotonNetwork.connected == true)
            {
                return;
            }
            Xcoord = Input.GetAxis("Horizontal") * Time.deltaTime;
            Zcoord = Input.GetAxis("Vertical") * Time.deltaTime;
            transform.Translate(Xcoord, 0, Zcoord);

        }
    }
}
