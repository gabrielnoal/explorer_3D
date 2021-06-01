using UnityEngine.Audio;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound ambienceSound;

    public AudioMixerGroup outputGroup;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        ambienceSound.source = gameObject.AddComponent<AudioSource>();
        ambienceSound.source.clip = ambienceSound.clip;
        ambienceSound.source.loop = ambienceSound.loop;
        ambienceSound.source.outputAudioMixerGroup = outputGroup;
        ambienceSound.source.volume = ambienceSound.volume;
        ambienceSound.source.pitch = ambienceSound.pitch;
    }

    // Update is called once per frame
    public void Start()
    {
        if (ambienceSound == null)
        {
            return;
        }
        ambienceSound.source.Play();
    }
}
