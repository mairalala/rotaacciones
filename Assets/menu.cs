
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    [Header("options")]

    public Slider volumeFX;
    public Slider volumeMAster;
    public Toggle mute;
    public AudioMixer mixer;
    public AudioSource fxsource;
    public AudioClip clip;
    public float lastvolume;

    [Header("panels")]

    public GameObject mainpanel;
    public GameObject optionspanel;
    public GameObject nivelespanel;

    private void Awake()
    {
        volumeFX.onValueChanged.AddListener(changeVolumeFX);
        volumeMAster.onValueChanged.AddListener(changeVolumeMaster);


    }

    public void playlevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
    public void setMute()
    {
        mixer.GetFloat("mastervolume", out lastvolume);
        if (mute.isOn)
        {
            mixer.SetFloat("mastervolume", -80);
        }
        else
        {
            mixer.SetFloat("mastervolume", lastvolume);

        }
    }

    public void openPanel(GameObject panel)
    {
        mainpanel.SetActive(false);
        optionspanel.SetActive(false);
        nivelespanel.SetActive(false);

        panel.SetActive(true);
        playsource();
    }

    public void changeVolumeMaster(float v)
    {
        mixer.SetFloat("mastervolume", v);
    }
    public void changeVolumeFX(float v)
    {
        mixer.SetFloat("fxvolume", v);
    }

    public void playsource()
    {
        fxsource.PlayOneShot(clip);
    }

}
