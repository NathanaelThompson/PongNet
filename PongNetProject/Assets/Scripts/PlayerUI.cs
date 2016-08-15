using UnityEngine;
using UnityEngine.UI;


using System.Collections;


namespace Com.ThoughtExperimentGames.PongNet
{
    public class PlayerUI : MonoBehaviour
    {


        #region Public Properties


        [Tooltip("UI Text to display Player's Name")]
        public Text PlayerNameText;

        [Tooltip("Pixel offset from the player target")]
        public Vector3 ScreenOffset = new Vector3(0f, 30f, 0f);

        // [Tooltip("UI Slider to display Player's Health")]
        // public Slider PlayerHealthSlider;


        #endregion


        #region Private Properties
        PlayerManager _target;
        float _characterControllerHeight = 0f;
        Transform _targetTransform;
        Vector3 targetPosition;
       // public GameObject PlayerUiPrefab;

        #endregion


        #region MonoBehaviour Messages
        void Awake()
        {
            this.GetComponent<Transform>().SetParent(GameObject.Find("Canvas").GetComponent<Transform>());
        }

        void Update()
        {
            //    // Reflect the Player Health
            //    if (PlayerHealthSlider != null)
            //    {
            //        PlayerHealthSlider.value = _target.Health;
            //    }
            // Destroy itself if the target is null, It's a fail safe when Photon is destroying Instances of a Player over the network
            if (_target == null)
            {
                Destroy(this.gameObject);
                return;
            }
            _targetTransform = _target.transform;
        }
        void Start()
        {
            //if (PlayerUiPrefab != null)
            //{
            //    GameObject _uiGo = Instantiate(PlayerUiPrefab) as GameObject;
            //    _uiGo.SendMessage("SetTarget", this, SendMessageOptions.RequireReceiver);
            //}
            //else {
            //    Debug.LogWarning("<Color=Red><a>Missing</a></Color> PlayerUiPrefab reference on player Prefab.", this);
            //}

        }
        void LateUpdate()
        {
            // #Critical
            // Follow the Target GameObject on screen.
            if (_targetTransform != null)
            {

                targetPosition = _targetTransform.position;
                targetPosition.y += _characterControllerHeight;
                this.transform.position = Camera.main.WorldToScreenPoint(targetPosition) + ScreenOffset;
            }
        }
        #endregion


        #region Public Methods
        public void SetTarget(PlayerManager target)
        {
            if (target == null)
            {
                Debug.LogError("<Color=Red><a>Missing</a></Color> PlayMakerManager target for PlayerUI.SetTarget.", this);
                return;
            }
            // Cache references for efficiency
            _target = target;
            _targetTransform = target.transform;
            if (PlayerNameText != null)
            {
                PlayerNameText.text = _target.photonView.owner.name;
            }
            newController newController = _target.GetComponent<newController>();
            // Get data from the Player that won't change during the lifetime of this Component
            if (newController != null)
            {
                _characterControllerHeight = newController.height;

            }
        }

        #endregion


    }
}