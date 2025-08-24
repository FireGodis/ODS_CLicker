using UnityEngine;

public class soundtrack_script : MonoBehaviour
{
    public AudioClip[] musicas;  // Array de músicas que você vai arrastar no inspector
    private AudioSource audioSource;
    private int musicaAtual = 0;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.loop = false; // não deixa repetir a mesma música, pois vamos controlar manualmente
        TocarMusica(musicaAtual);
    }

    void Update()
    {
        // Quando a música terminar, tocar a próxima
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
        if (musicas.Length == 0) return; // se não tiver música, não faz nada
        audioSource.clip = musicas[index];
        audioSource.Play();
    }
}
