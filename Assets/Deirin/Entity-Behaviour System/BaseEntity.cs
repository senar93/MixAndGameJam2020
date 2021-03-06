﻿namespace Deirin.EB {
    using System.Collections.Generic;
    using UltEvents;
    using UnityEngine;
    using NaughtyAttributes;

    public abstract class BaseEntity : MonoBehaviour {
        public UltEvent OnSetup;

        public BaseBehaviour[] Behaviours { get; private set; }
        public bool active { get; private set; }

        public void Setup () {
            if ( Behaviours != null )
                for ( int i = 0; i < Behaviours.Length; i++ ) {
                    Behaviours[i].Setup( this );
                }
            active = true;
            CustomSetup();
            OnSetup.Invoke();
        }

        public void SetupWithFetch () {
            FetchBehaviours();
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].Setup( this );
            }
            active = true;
            CustomSetup();
            OnSetup.Invoke();
        }

        //[Button("Fetch Behaviours")]
        public void FetchBehaviours () => Behaviours = GetComponentsInChildren<BaseBehaviour>();

        protected virtual void CustomSetup () {

        }

        /// <summary>
        /// Returns the first behaviour found of the specified type (null if none is found).
        /// </summary>
        /// <typeparam name="T">Behaviour class type</typeparam>
        /// <returns></returns>
        public T GetBehaviour<T> () where T : BaseBehaviour {
            T obj = null;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                if ( Behaviours[i] is T ) {
                    obj = Behaviours[i] as T;
                    break;
                }
            }
            return obj;
        }

        public bool TryGetBehaviour<T> ( out T b ) where T : BaseBehaviour {
            b = null;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                if ( Behaviours[i] is T ) {
                    b = Behaviours[i] as T;
                    break;
                }
            }
            return b != null;
        }

        public bool HasBehaviour<T> () where T : BaseBehaviour {
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                if ( Behaviours[i] is T ) {
                    return true;
                }
            }
            return false;
        }

        public List<T> GetBehaviours<T> () where T : BaseBehaviour {
            List<T> objs = new List<T>();
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                if ( Behaviours[i] is T )
                    objs.Add( Behaviours[i] as T );
            }
            return objs;
        }

        private void OnEnable () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnOnEnable();
            }
        }

        private void Awake () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnAwake();
            }
        }

        private void Start () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnStart();
            }
        }

        private void Update () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnUpdate();
            }
        }

        private void LateUpdate () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnLateUpdate();
            }
        }

        private void FixedUpdate () {
            if ( !active )
                return;
            for ( int i = 0; i < Behaviours.Length; i++ ) {
                Behaviours[i].OnFixedUpdate();
            }
        }
    }
}