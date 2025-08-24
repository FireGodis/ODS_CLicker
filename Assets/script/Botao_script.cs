using UnityEngine;
using UnityEngine.UI;
using TMPro;

using System.Collections;


public class Botao_script : MonoBehaviour
{
    public TextMeshProUGUI quantMoedasText; // Arraste o objeto "quant_moedas" do Canvas aqui pelo Inspector
    private int moedas = 0;
    public TextMeshPro textomoeda_loja;
    public int ONG_Compradas = 0;
    public int GOV_Compradas = 0;
    public TextMeshPro ONG_text;
    public TextMeshPro GOV_text;
    public GameObject botao; // Arraste o objeto do bot�o aqui pelo Inspector
    public ParticleSystem particula;
    private Vector3 escalaOriginal; // <--- escala armazenada
    private int custoONG = 25;
    private int custoGOV = 1000;   
    public TextMeshPro custoONG_text; // Arraste o objeto "custo ONG" do Canvas aqui pelo Inspector
    public TextMeshPro custoGOV_text; // Arraste o objeto "custo GOV" do Canvas aqui pelo Inspector
    public TextMeshProUGUI textohit;
    public GameObject saldo_insuONG;
    public GameObject saldo_insuGOV;

    public GameObject botaoONG;
    public GameObject botaoGOV;
    public TextMeshProUGUI quant_moedas;
    public SpriteRenderer mapa; // mudei para Image porque Sprite sozinho n�o tem cor
    private int moedasMax = 10000;

    private Button botao_parceria_button;

    // Fun��o chamada quando o bot�o for clicado
    public void AdicionarMoeda()
    {
        // Valor base
        int valorDoClique = 1;

        // Cada ONG d� +2 por clique
        valorDoClique += ONG_Compradas * 2;

        // Cada GOV d� +10 por clique
        valorDoClique += GOV_Compradas * 10;

        // Soma ao total de moedas
        moedas += valorDoClique;

        AtualizarTexto();
        StartCoroutine(AnimarBotao());
        CriarParticulaNaPosicaoDoMouse();
        AnimacaoHit(valorDoClique);
        AnimarHitText(textohit);
    }

    private void AnimacaoHit(int valor)
    {
        // Calcula o valor do hit
        int valorHit = valor;

        // Pega posi��o do mouse em coordenadas de tela
        Vector3 posMouse = Input.mousePosition;

        // Converte para posi��o no mundo da UI (Canvas)
        posMouse.z = 0f;
        Vector3 posMundo = Camera.main.ScreenToWorldPoint(posMouse);

        // Cria o texto tempor�rio
        TextMeshProUGUI hitText = Instantiate(textohit, transform.parent);
        hitText.text = "+" + valorHit.ToString();

        // Ajusta posi��o
        hitText.transform.position = posMouse;

        // J� aparece em escala vis�vel
        hitText.transform.localScale = Vector3.one;

        // Inicia a anima��o imediatamente
        StartCoroutine(AnimarHitText(hitText));
    }

    private IEnumerator AnimarHitText(TextMeshProUGUI hitText)
    {
        float duracao = 0.1f; // mais r�pido e imediato
        float tempo = 0f;

        Vector3 posInicial = hitText.transform.position;
        Vector3 posFinal = posInicial + new Vector3(0, 90f, 0); // leve subida

        Color corInicial = hitText.color;
        Color corFinal = new Color(corInicial.r, corInicial.g, corInicial.b, 0);

        while (tempo < duracao)
        {
            tempo += Time.deltaTime;
            float t = tempo / duracao;

            // Movimento pra cima + curva suave
            hitText.transform.position = Vector3.Lerp(posInicial, posFinal, Mathf.SmoothStep(0, 3, t));

            // Escala crescendo levemente
            hitText.transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 4f, Mathf.SmoothStep(0, 5, t));

            // Fade-out progressivo
            hitText.color = Color.Lerp(corInicial, corFinal, t);

            yield return null;
        }

        Destroy(hitText.gameObject);
    }

    public void ComprarONG(){
                if (moedas >= custoONG) // Verifica se h� moedas suficientes
        {
            moedas -= custoONG; // Subtrai 25 moedas
            ONG_Compradas++; // Incrementa o contador de ONGs compradas
            custoONG += 25; // Aumenta o custo para a pr�xima compra    

            ONG_text.text = ONG_Compradas.ToString(); // Atualiza o texto da ONG
            custoONG_text.text = custoONG.ToString(); // Atualiza o texto do custo da ONG
            AtualizarTexto();
        }
        else
        {
            
            botao_parceria_button.interactable = false;
            StartCoroutine(MostrarMensagemTemporaria());
            
        }
    }

    private IEnumerator MostrarMensagemTemporaria()
    {
        saldo_insuONG.SetActive(true);   // ativa o objeto
        

        yield return new WaitForSeconds(2f);  // espera 2 segundos
        
        
        saldo_insuONG.SetActive(false);  // desativa
    }
    public void ComprarGOV()
    {
        if (moedas >= custoGOV) // Verifica se h� moedas suficientes
        {
            moedas -= custoGOV; // Subtrai 1000 moedas
            GOV_Compradas++; // Incrementa o contador de GOV compradas
            custoGOV += 1000; // Aumenta o custo para a pr�xima compra

            GOV_text.text = GOV_Compradas.ToString();
            custoGOV_text.text = custoGOV.ToString(); // Atualiza o texto da ONG
            AtualizarTexto();
        }
        else
        {
            Debug.Log("Moedas insuficientes para comprar a GOV.");
        }
    }

    public void Start()
    {
        // Guarda a escala original do bot�o no primeiro frame
        escalaOriginal = botao.transform.localScale;
        
        botao_parceria_button = this.GetComponent<Button>();
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
        // Atualiza os textos
        quantMoedasText.text = moedas.ToString();
        textomoeda_loja.text = moedas.ToString();

        // --- fiscaliza��o do valor das moedas ---
        float t = Mathf.Clamp01((float)moedas / moedasMax);
        mapa.color = Color.Lerp(Color.black, Color.white, t);
    }
}

