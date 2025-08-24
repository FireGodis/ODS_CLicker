using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.EditorTools;


public class Botao_script : MonoBehaviour
{
    public TextMeshProUGUI quantMoedasText; // Arraste o objeto "quant_moedas" do Canvas aqui pelo Inspector
    private int moedas = 0;
    public GameObject botao; // Arraste o objeto do botão aqui pelo Inspector
    public ParticleSystem particula;
    private Vector3 escalaOriginal; // <--- escala armazenada

    // Função chamada quando o botão for clicado
    public void AdicionarMoeda()
    {
        moedas++; // soma +1
        AtualizarTexto();
        StartCoroutine(AnimarBotao());
        CriarParticulaNaPosicaoDoMouse();
    }

    public void Start()
    {
        // Guarda a escala original do botão no primeiro frame
        escalaOriginal = botao.transform.localScale;
    }


    private void CriarParticulaNaPosicaoDoMouse()
    {
        // Pega posição do mouse em coordenadas de tela
        Vector3 posMouse = Input.mousePosition;

        // Converte para posição do mundo
        posMouse.z = 2f; // distância da câmera
        Vector3 posMundo = Camera.main.ScreenToWorldPoint(posMouse);

        // Instancia partícula na posição
        ParticleSystem p = Instantiate(particula, posMundo, Quaternion.identity);

        // Garante que a partícula toque
        p.Play();

        // Destroi automaticamente após a duração da partícula
        Destroy(p.gameObject, 5f);
    }

    private System.Collections.IEnumerator AnimarBotao()
    {


        // Reduz um pouco o tamanho (efeito de "clicar")
        botao.transform.localScale = escalaOriginal * 0.9f;

        // Espera 0.1s
        yield return new WaitForSeconds(0.2f);

        // Volta pro tamanho original
        botao.transform.localScale = escalaOriginal;
    }

    private void AtualizarTexto()
    {
        quantMoedasText.text = moedas.ToString();
    }
}

