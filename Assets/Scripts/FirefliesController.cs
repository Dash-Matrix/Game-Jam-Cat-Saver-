using UnityEngine;
using DG.Tweening;

public class FirefliesController : MonoBehaviour
{
    [SerializeField] private GameObject[] fireflies; // Array of firefly objects
    [SerializeField] private Vector2 moveRadius = new Vector2(5f, 3f); // X and Y movement range
    [SerializeField] private float moveDuration = 2f; // Time taken for each movement
    [SerializeField] private float delayBetweenMoves = 0.5f; // Delay before next move
    private Vector2 originPosition; // Center position for movement restriction

    private void Start()
    {
        originPosition = transform.position; // The central position for movement

        foreach (GameObject firefly in fireflies)
        {
            MoveFirefly(firefly);
        }
    }

    private void MoveFirefly(GameObject firefly)
    {
        Vector2 randomPosition = GetRandomPositionWithinRectangle();

        firefly.transform.DOMove(randomPosition, moveDuration)
            .SetEase(Ease.Linear) // Smooth motion
            .OnComplete(() =>
                DOVirtual.DelayedCall(delayBetweenMoves, () => MoveFirefly(firefly))
            );
    }

    private Vector2 GetRandomPositionWithinRectangle()
    {
        float randomX = Random.Range(-moveRadius.x, moveRadius.x);
        float randomY = Random.Range(-moveRadius.y, moveRadius.y);
        return originPosition + new Vector2(randomX, randomY);
    }
}
