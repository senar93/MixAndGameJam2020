﻿namespace Deirin.Utilities {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.EB;

    public static class CustomUnityEvents {

    }

    [System.Serializable]
    public class UnityEvent_Float : UnityEvent<float> { }

    [System.Serializable]
    public class UnityEvent_Int : UnityEvent<int> { }

    [System.Serializable]
    public class UnityEvent_String : UnityEvent<string> { }

    [System.Serializable]
    public class UnityEvent_Bool : UnityEvent<bool> { }

    [System.Serializable]
    public class UnityEvent_Component : UnityEvent<Component> { }

    [System.Serializable]
    public class UnityEvent_Vector3Array : UnityEvent<Vector3[]> { }

    [System.Serializable]
    public class UnityEvent_Color : UnityEvent<Color> { }

    [System.Serializable]
    public class UnityEvent_Entity : UnityEvent<BaseEntity> { }

    [System.Serializable]
    public class UnityEvent_Behaviour : UnityEvent<BaseBehaviour> { }

    [System.Serializable]
    public class UnityEvent_Transform : UnityEvent<Transform> { }

    [System.Serializable]
    public class UnityEvent_Vector2 : UnityEvent<Vector2> { }

    [System.Serializable]
    public class UnityEvent_Vector3 : UnityEvent<Vector3> { }

	[System.Serializable]
	public class UnityEvent_GameObject : UnityEvent<GameObject> { }

    [System.Serializable]
    public class UnityEvent_Enum : UnityEvent<System.Enum> { }
}
