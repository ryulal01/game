using UnityEngine;

public class GroundLooper : MonoBehaviour
{
    [Header("Player Reference")]
    [SerializeField] private Transform player; // ссылка на игрока

    [Header("Ground Settings")]
    [SerializeField] private float groundLength = 100f; // длина одного сегмента

    private void Update()
    {
        // если игрок прошёл за границу этого пола — перемещаем его вперёд
        if (player.position.z > transform.position.z + groundLength)
        {
            transform.position += new Vector3(0, 0, groundLength * 2);
        }
    }
}
