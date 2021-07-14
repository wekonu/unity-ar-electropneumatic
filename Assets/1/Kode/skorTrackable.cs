/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class skorTrackable : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public Animator Animasi;
        public string onTracking;
        public string onMissing;

        public AudioSource soundTarget;
        public AudioClip clipTarget;

        void stopAudio()
        {
            soundTarget.Stop();
        }

        void playAudio()
        {
            soundTarget.clip = clipTarget;
            soundTarget.Play();
        }

        [SerializeField]
        private TextMesh score;

        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        #endregion // PRIVATE_MEMBER_VARIABLES



        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }
            Animasi.GetComponent<Animator>();
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS



        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        #endregion // PUBLIC_METHODS



        #region PRIVATE_METHODS


        private void OnTrackingFound()
        {
            /*
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(true);
            }
             */

            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            if (onTracking != "") Animasi.Play(onTracking);
            score.text = PlayerPrefs.GetString("gameScore");

            if (PlayerPrefs.GetString("sound") == "enabled")
            {
                playAudio();
            }
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(false);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(false);

            // Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = false;
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = false;
            }

            //Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            if (onMissing != "")
                Animasi.Play(onMissing);
            else
                Animasi.StopPlayback();

            if (PlayerPrefs.GetString("sound") == "enabled")
            {
                stopAudio();
            }
        }

        #endregion // PRIVATE_METHODS
    }
}
