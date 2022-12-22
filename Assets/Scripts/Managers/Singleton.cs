using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : class
{
    public bool DontDestroy = false;
    [SerializeField] static Singleton<T> _instance;
    public static T Instance
    {
        get
        {
            return _instance as T;
        }
    }

    protected virtual void Awake()
    {
        CheckInstance(this);

        if (DontDestroy)
        {
            DontDestroyOnLoad(gameObject);
        }

        Initialize();
    }

    private static void CheckInstance(Singleton<T> instance)
    {
        if (_instance == null)
        {
            _instance = instance;
        }
        else
        {
            if (_instance != instance)
            {
                Destroy(instance);

                if (instance.gameObject != null)
                {
                    Destroy(instance.gameObject);
                }

                return;
            }
        }
    }

    protected virtual void Initialize()
    {

    }

    protected virtual void Shutdown()
    {

    }

    protected virtual void OnDestroy()
    {
        if (_instance == this)
        {
            _instance = null;
            Shutdown();
        }
    }

    protected virtual void OnApplicationQuit()
    {
        if (_instance == this)
        {
            _instance = null;
            Shutdown();
        }
    }
}