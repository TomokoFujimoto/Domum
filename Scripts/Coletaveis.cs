using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coletaveis : MonoBehaviour
{
    public Text txtFelicidade;
    private int scrFelicidade;
    public int QuantoValeFelicidade;

    // Start is called before the first frame update
    void Start()
    {
        scrFelicidade = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        scrFelicidade += QuantoValeFelicidade;
        txtFelicidade.text = scrFelicidade.ToString();
        Debug.Log("colidiu");
    }
}
