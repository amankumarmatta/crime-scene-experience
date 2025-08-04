using UnityEngine;

public class FlashlightController : MonoBehaviour
{
    public Light flashlight;

    private bool isFlashlightOn = false;

    public void ToggleFlashlight()
    {
        AudioManager.Instance.PlayClick();
        isFlashlightOn = !isFlashlightOn;
        flashlight.enabled = isFlashlightOn;
    }
}
