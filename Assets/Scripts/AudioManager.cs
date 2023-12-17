using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sfxSlider;

    const string masterVolume = "MasterVolume";
    const string musicVolume = "MusicVolume";
    const string sfxVolume = "SFXVolume";

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        volumeSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);

    }

    public void SetMasterVolume(float value)
    {
        mixer.SetFloat(masterVolume, Mathf.Log10(value) * 20);
    }

    public void SetMusicVolume(float value)
    {
        mixer.SetFloat(musicVolume, Mathf.Log10(value) * 20);
    }

    public void SetSFXVolume(float value)
    {
        mixer.SetFloat(sfxVolume, Mathf.Log10(value) * 20);
    }
}
