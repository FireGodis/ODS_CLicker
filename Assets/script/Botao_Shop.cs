using UnityEngine;

public class Botao_Shop : MonoBehaviour
{

    public GameObject botao;
    public GameObject terra;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void Abrir_Loja()
    {
        TrocarTela();
    }

    private void TrocarTela()
    {

    }

    // Update is called once per frame
    void Update()
    {
        terra.transform.Rotate(0, 0, 10 * Time.deltaTime);
    }
}
