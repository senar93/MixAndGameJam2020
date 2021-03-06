﻿namespace Deirin.Utilities {
    using UnityEngine;
    using Cinemachine;
    using DG.Tweening;
    using UltEvents;

    public class CinemachineNoiseController : MonoBehaviour {
        [Header("Refs")]
        public CinemachineVirtualCamera cam;

        [Header("Params")]
        public bool setupOnAwake = true;
        [Space]
        //public NoiseSettings noiseProfile;
        public float amplitudeGain;
        public float frequencyGain;
        public Vector3 pivotOffset;
        [Space]
        public float duration;

        [Header("Events")]
        public UltEvent OnPlay;
        public UltEvent OnEnd;

        private CinemachineBasicMultiChannelPerlin noise;
        private Sequence s;

        private void Awake () {
            if ( setupOnAwake )
                Setup();
        }

        public void Setup () {
            noise = cam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        public void Play () {
            noise.m_AmplitudeGain = amplitudeGain;
            noise.m_FrequencyGain = frequencyGain;
            //noise.m_PivotOffset = pivotOffset;

            s = DOTween.Sequence();
            s.AppendInterval( duration );
            s.onComplete += End;

            s.PlayForward();

            OnPlay.Invoke();
        }

        public void Stop () {
            s.Kill();
            End();
        }

        public void SetAmplitudeGain ( float value ) {
            noise.m_AmplitudeGain = value;
        }

        public void SetFrequencyGain ( float value ) {
            noise.m_FrequencyGain = value;
        }

        public void SetDuration ( float value ) {
            duration = value;
        }

        private void End () {
            noise.m_AmplitudeGain = 0;
            noise.m_FrequencyGain = 0;
            //noise.m_PivotOffset = Vector3.zero;
            s.Kill();

            OnEnd.Invoke();
        }
    }
}