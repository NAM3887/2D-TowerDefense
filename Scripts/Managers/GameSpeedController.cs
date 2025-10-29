using UnityEngine;

public class GameSpeedController : MonoBehaviour
{
    [SerializeField] private float normalSpeed = 1f;
    [SerializeField] private float fastForwardSpeed = 2f;

    private bool isFastForwarding = false;

    public void ToggleFastForward()
    {
        isFastForwarding = !isFastForwarding;
        Time.timeScale = isFastForwarding ? fastForwardSpeed : normalSpeed;
    }

    public void ResetSpeed()
    {
        Time.timeScale = normalSpeed;
        isFastForwarding = false;
    }
}