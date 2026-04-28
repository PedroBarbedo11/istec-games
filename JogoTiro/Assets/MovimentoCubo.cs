using UnityEngine;

public class MovimentoCubo : MonoBehaviour
{
    [Header("Configurações de Movimento")]
    public float velocidadeMovimento = 10f;
    public float sensibilidadeRato = 2f;

    private float rotacaoY = 0f;

    void Start()
    {
        // Opcional: Esconde o rato e prende-o no centro do ecrã
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // 1. ROTAÇÃO com o Rato
        float ratoX = Input.GetAxis("Mouse X") * sensibilidadeRato;
        rotacaoY += ratoX;

        // Aplica a rotação apenas no eixo Y (esquerda/direita)
        transform.localRotation = Quaternion.Euler(0f, rotacaoY, 0f);

        // 2. MOVIMENTO com o Teclado (WASD / Setas)
        float moverHorizontal = Input.GetAxis("Horizontal"); // A/D ou Setas Esq/Dir
        float moverVertical = Input.GetAxis("Vertical");     // W/S ou Setas Cima/Baixo

        // Criamos um vetor de direção baseado no input
        Vector3 direcao = new Vector3(moverHorizontal, 0f, moverVertical);

        // Move o objeto em relação ao seu próprio eixo "Forward" (Frente)
        // Isso garante que o 'W' seja sempre para onde o cubo está a olhar
        transform.Translate(direcao * velocidadeMovimento * Time.deltaTime, Space.Self);
    }
}