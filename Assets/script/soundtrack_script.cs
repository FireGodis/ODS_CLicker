using UnityEngine;

public class soundtrack_script : MonoBehaviour
{
    public AudioClip[] musicas;  // Array de m�sicas que voc� vai arrastar no inspector
    private AudioSource audioSource;
    private int musicaAtual = 0;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false; // n�o deixa repetir a mesma m�sica, pois vamos controlar manualmente
        TocarMusica(musicaAtual);
    }

    void Update()
    {
        // Quando a m�sica terminar, tocar a pr�xima
        if (!audioSource.isPlaying)
        {
            musicaAtual++;
            if (musicaAtual >= musicas.Length)
            {
                musicaAtual = 0; // volta para a primeira
            }
            TocarMusica(musicaAtual);
        }
    }

    void TocarMusica(int index)
    {
        if (musicas.Length == 0) return; // se n�o tiver m�sica, n�o faz nada
        audioSource.clip = musicas[index];
        audioSource.Play();
    }
}
