using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.Rendering;
public class ChangePostProcesing : MonoBehaviour
{
    private Vignette vignette;
    public PostProcessVolume Post;
    public float NewVignette;
    public SettingsMenu Settings;
    public void Start()
    {
        vignette = Post.profile.GetSetting<Vignette>();
        vignette.intensity.value = 0;

    }
    void Update()
    {
        vignette.intensity.value = NewVignette;
    }
    public void FinaVignette()
    {
        if (Settings.vignetteToggle.isOn == true)
        {
            vignette.intensity.value = 0.3f;
        }
        else
        {
            NewVignette = 0;

        }
    }
}
