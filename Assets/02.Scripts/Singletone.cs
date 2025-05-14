using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singletone<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Singletone")]
    [SerializeField] protected bool m_IsDestroy;
    private static T m_Instance;

    public static T Instance
    {
        get
        {
            if (m_Instance != null) return m_Instance;

            m_Instance = (T)FindObjectOfType(typeof(T));

            if (m_Instance != null) return m_Instance;

            var obj = new GameObject();
            m_Instance = obj.AddComponent(typeof(T)) as T;
            obj.name = typeof(T).ToString();

            DontDestroyOnLoad(obj);

            return m_Instance;
        }
        protected set => m_Instance = value;
    }

    private void Awake()
    {
        Instance = this.GetComponent(typeof(T)) as T;
        if (m_IsDestroy)
        {
            DontDestroyOnLoad(this);
        }
        SingletonAwake();
    }

    protected virtual void SingletonAwake()
    {
    }
}