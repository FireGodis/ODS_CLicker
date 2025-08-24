using TMPro;
using UnityEngine;
using UnityEngine.UI; // necessário para mexer com Image

public class mapa_script : MonoBehaviour
{
    public TextMeshProUGUI quant_moedas;
    public SpriteRenderer mapa; // mudei para Image porque Sprite sozinho não tem cor
    private int moedasMax = 10000;

    void Update()
    {
        // tenta converter o texto para inteiro
        int moedasAtuais = 0;
        int.TryParse(quant_moedas.text, out moedasAtuais);

        // normaliza o valor entre 0 e 1
        float t = Mathf.Clamp01((float)moedasAtuais / moedasMax);

        // faz o Lerp de preto até branco
        mapa.color = Color.Lerp(Color.black, Color.white, t);
    }
}
