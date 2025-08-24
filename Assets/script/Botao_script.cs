using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor.EditorTools;


public class Botao_script : MonoBehaviour
{
    public TextMeshProUGUI quantMoedasText; // Arraste o objeto "quant_moedas" do Canvas aqui pelo Inspector
    private int moedas = 0;
    public GameObject botao; // Arraste o objeto do bot�o aqui pelo Inspector
    public ParticleSystem particula;
    private Vector3 escalaOriginal; // <--- escala armazenada

    // Fun��o chamada quando o bot�o for clicado
    public void AdicionarMoeda()
    {
        moedas++; // soma +1
        AtualizarTexto();
        StartCoroutine(AnimarBotao());
        CriarParticulaNaPosicaoDoMouse();
    }

    public void Start()
    {
        // Guarda a escala original do bot�o no primeiro frame
        escalaOriginal = botao.transform.localScale;
    }


    private void CriarParticulaNaPosicaoDoMouse()
    {
        // Pega posi��o do mouse em coordenadas de tela
        Vector3 posMouse = Input.mousePosition;

        // Converte para posi��o do mundo
        posMouse.z = 2f; // dist�ncia da c�mera
        Vector3 posMundo = Camera.main.ScreenToWorldPoint(posMouse);

        // Instancia part�cula na posi��o
        ParticleSystem p = Instantiate(particula, posMundo, Quaternion.identity);

        // Garante que a part�cula toque
        p.Play();

        // Destroi automaticamente ap�s a dura��o da part�cula
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

