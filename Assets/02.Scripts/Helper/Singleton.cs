using UnityEngine;

public class Singletone<T> : MonoBehaviour where T : MonoBehaviour
{
    [Header("Singletone")]
    [SerializeField] protected bool IsDestroy;
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance != null) return _instance;

            _instance = (T)FindFirstObjectByType(typeof(T));

            if (_instance != null) return _instance;

            var obj = new GameObject();
            _instance = obj.AddComponent(typeof(T)) as T;
            obj.name = typeof(T).ToString();

            DontDestroyOnLoad(obj);

            return _instance;
        }
        protected set => _instance = value;
    }

    private void Awake()
    {
        Instance = this.GetComponent(typeof(T)) as T;
        if (IsDestroy)
        {
            DontDestroyOnLoad(this);
        }
        SingletonAwake();
    }

    protected virtual void SingletonAwake()
    {
    }
}