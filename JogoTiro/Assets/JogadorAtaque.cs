using UnityEngine;

public class JogadorAtaque : MonoBehaviour
{
    [Header("Referências")]
    public GameObject prefabBala; // O objeto esférico que vamos disparar
    public Transform pontoDeDisparo; // De onde a bala sai (vazio à frente do cubo)

    [Header("Configurações")]
    public float cadenciaTiro = 0.5f; // Tempo mínimo entre tiros

    private float proximoTiroTempo = 0f;

    void Update()
    {
        // Deteta o clique esquerdo do rato (Fire1) E verifica se já pode disparar de novo
        if (Input.GetButton("Fire1") && Time.time >= proximoTiroTempo)
        {
            Atacar();
            proximoTiroTempo = Time.time + cadenciaTiro; // Define quando será o próximo tiro
        }
    }

    void Atacar()
    {
        // Se não configuraste os pontos, avisa no console para não dar erro
        if (prefabBala == null || pontoDeDisparo == null)
        {
            Debug.LogWarning("Por favor, atribua o Prefab da Bala e o Ponto de Disparo no Inspector do Cubo.");
            return;
        }

        // --- O SEGREDO DO DISPARO ---
        // Criamos uma cópia do prefab na posição e rotação exata do 'pontoDeDisparo'
        // Como o ponto está preso ao Cubo, ele já sai na direção correta.
        Instantiate(prefabBala, pontoDeDisparo.position, pontoDeDisparo.rotation);
    }
}
