using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class LowOxygenEffect : MonoBehaviour
{
    PostProcessVolume _volume;
    Vignette _vignette;
    public float effectIntensity = 0f;
    private PlayerOxygen playerOxygen;
    private bool isEffectPlaying = false;
    public AudioSource lowOxygenSound;
    private PauseMenuScript pauseMenuScript;

    // Start is called before the first frame update
    void Start()
    {
        pauseMenuScript = FindObjectOfType<PauseMenuScript>();

        playerOxygen = FindObjectOfType<PlayerOxygen>();
        _volume = GetComponent<PostProcessVolume>();
        _volume.profile.TryGetSettings<Vignette>(out _vignette);
        _vignette.enabled.Override(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerOxygen.currentOxygen < 40 && !pauseMenuScript.isPaused)
        {
            if(!lowOxygenSound.isPlaying) lowOxygenSound.Play();
            if(!isEffectPlaying) StartCoroutine(LowOxygen());
        }
        else
        {
            if (lowOxygenSound.isPlaying) lowOxygenSound.Stop();
        }


    }

    private IEnumerator LowOxygen()
    {
        isEffectPlaying = true;
        effectIntensity = 0.4f;
        _vignette.enabled.Override(true);
        _vignette.intensity.Override(0.4f);
        yield return new WaitForSeconds(0.4f);
        while (effectIntensity > 0)
        {
            effectIntensity -= 0.05f;
            if (effectIntensity < 0) effectIntensity = 0;
            _vignette.intensity.Override(effectIntensity);
            yield return new WaitForSeconds(0.1f);
        }
        _vignette.enabled.Override(false);
        isEffectPlaying = false;
        yield break;
    }
}
