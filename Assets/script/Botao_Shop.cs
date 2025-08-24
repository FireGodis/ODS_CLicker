using UnityEngine;
using UnityEngine.UI;

public class Botao_Shop : MonoBehaviour
{
    public GameObject botao;
    public GameObject botaoLoja;
    public GameObject botaoParceria;
    public GameObject botaoONG;
    public GameObject botaoGOV;
    public GameObject terra;
    public GameObject fundo_loja;
    public GameObject dinheiro;
    public GameObject ODSletra;
    public GameObject saldo_insuONG;
    public GameObject saldo_insuGOV;

    private Button botao_parceria_button;






    private Vector3 PosOriginal = new Vector3(-6.35f, 0, -3);
    private Vector3 PosFinal = new Vector3(-0.04f, 0, -3);

    public float velocidadeSuave = 5f; // quanto maior, mais rápido o movimento
    private Vector3 velocidadeAtual = Vector3.zero; // usado pelo SmoothDamp
    private bool abrir = false;

    void Start()
    {
        fundo_loja.transform.position = PosOriginal;
        botao_parceria_button = botaoParceria.GetComponent<Button>();
    }

    public void Abrir_Loja()
    {
        botaoLoja.SetActive(true);
        botaoONG.SetActive(true);
        botaoGOV.SetActive(true);
        terra.SetActive(false);
        dinheiro.SetActive(false);
        ODSletra.SetActive(false);
        botao_parceria_button.interactable = false;

        abrir = true;
    }

    public void Fechar_Loja()
    {
        abrir = false;
        
    }

    void Update()
    {
        // Rotação da terra
        terra.transform.Rotate(0, 0, 20 * Time.deltaTime);

        // Movimentação suave do fundo
        Vector3 alvo = abrir ? PosFinal : PosOriginal;
        fundo_loja.transform.position = Vector3.SmoothDamp(fundo_loja.transform.position, alvo, ref velocidadeAtual, 1f / velocidadeSuave);

        // Desativa botão quando voltar à posição original
        if (!abrir && Vector3.Distance(fundo_loja.transform.position, PosOriginal) < 0.01f)
        {
            botaoLoja.SetActive(false);
            botaoONG.SetActive(false);
            botaoGOV.SetActive(false);
            terra.SetActive(true);
            dinheiro.SetActive(true);
            ODSletra.SetActive(true);
            saldo_insuONG.SetActive(false);
            saldo_insuGOV.SetActive(false);
            botao_parceria_button.interactable = true;
        }
    }
}
