using UnityEngine;

public class DontDestroyUI : MonoBehaviour
{
    private static DontDestroyUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
