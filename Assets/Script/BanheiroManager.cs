using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BanheiroManager : MonoBehaviour
{
    public GameObject sabonete, toalha,  chuveiro, shampoo, sabonetePreto, toalhaPreto, chuveiroPreto, shampooPreto;
    
    //banheiro
    Vector2 saboneteinitialPos, toalhainitialPos, shampooinitialPos, chuveiroinitialPos;
    public AudioSource pesquisaItensBanheiro;
    public AudioClip[] corretoItensBanheiro;
    public AudioClip[] inCorretoBanheiro;
    bool saboneteCorreto, toalhaCorreto, chuveiroCorreto, shampooCorreto = false;
    float timer = 0.0f;
    int seconds = 0;
    
    [SerializeField]
    public Text contadorItensBanheiroText;
    private int contadorItensBanheiro;

    void Start(){
        contadorItensBanheiro = 0;
        pesquisaItensBanheiro = gameObject.GetComponent<AudioSource>();
        
        //banheiro
        saboneteinitialPos = sabonete.transform.position;
        toalhainitialPos = toalha.transform.position;
        shampooinitialPos = shampoo.transform.position;
        chuveiroinitialPos = chuveiro.transform.position;
    }

    public void DragSabonete(){
        sabonete.transform.position = Input.mousePosition;
    }

    public void DragToalha(){
        toalha.transform.position = Input.mousePosition;
    }

    public void DragChuveiro(){
        chuveiro.transform.position = Input.mousePosition;
    }

    public void DragShampoo(){
        shampoo.transform.position = Input.mousePosition;
    }

    public void DropSabonete(){
        float Distance = Vector3.Distance(sabonete.transform.position, sabonetePreto.transform.position);
        if (Distance < 50){
            sabonete.transform.position = sabonetePreto.transform.position;
            pesquisaItensBanheiro.clip = corretoItensBanheiro[1];//[Random.Range(0, corretoItensBanheiro.Length)];
            pesquisaItensBanheiro.Play();
            contadorItensBanheiro += 1;
            saboneteCorreto = true;
            alterarImagem(sabonete, sabonetePreto);
        }else{
            sabonete.transform.position = saboneteinitialPos;
            pesquisaItensBanheiro.clip = inCorretoBanheiro[1];
            pesquisaItensBanheiro.Play();
        }
    } 

    public void DropToalha(){
        float Distance = Vector3.Distance(toalha.transform.position, toalhaPreto.transform.position);
        if (Distance < 50){
            toalha.transform.position = toalhaPreto.transform.position;
            pesquisaItensBanheiro.clip = corretoItensBanheiro[2];//[Random.Range(0, corretoItensBanheiro.Length)];
            pesquisaItensBanheiro.Play();
            contadorItensBanheiro += 1;
            toalhaCorreto = true;
            alterarImagem(toalha, toalhaPreto);
        }else{
            toalha.transform.position = toalhainitialPos;
            pesquisaItensBanheiro.clip = inCorretoBanheiro[2];
            pesquisaItensBanheiro.Play();
        }
    }

    public void DropChuveiro(){
        float Distance = Vector3.Distance(chuveiro.transform.position, chuveiroPreto.transform.position);
        if (Distance < 50){
            chuveiro.transform.position = chuveiroPreto.transform.position;
            pesquisaItensBanheiro.clip = corretoItensBanheiro[0];//[Random.Range(0, corretoItensBanheiro.Length)];
            pesquisaItensBanheiro.Play();
            contadorItensBanheiro += 1;
            chuveiroCorreto = true;
            alterarImagem(chuveiro, chuveiroPreto);
        }else{
            chuveiro.transform.position = chuveiroinitialPos;
            pesquisaItensBanheiro.clip = inCorretoBanheiro[0];
            pesquisaItensBanheiro.Play();
        }
    } 

    public void DropShampoo(){
        float Distance = Vector3.Distance(shampoo.transform.position, shampooPreto.transform.position);
        if (Distance < 50){
            shampoo.transform.position = shampooPreto.transform.position;
            pesquisaItensBanheiro.clip = corretoItensBanheiro[3];//[Random.Range(0, corretoItensBanheiro.Length)];
            pesquisaItensBanheiro.Play();
            contadorItensBanheiro += 1;
            shampooCorreto = true;
            alterarImagem(shampoo, shampooPreto);
        }else{
            shampoo.transform.position = shampooinitialPos;
            pesquisaItensBanheiro.clip = inCorretoBanheiro[3];
            pesquisaItensBanheiro.Play();
        }
    } 

    private void alterarImagem(GameObject imagem, GameObject imagemPreto)
    {
        imagem.GetComponent<Image>().enabled = false;
        imagemPreto.GetComponent<Image>().color = new Color(255,255,255);
    }

    void Update(){

        Debug.Log(contadorItensBanheiro);
        
        contadorItensBanheiroText.text = "Itens: "+ contadorItensBanheiro.ToString();
        if(toalhaCorreto && chuveiroCorreto && saboneteCorreto && shampooCorreto){

            timer += Time.deltaTime;
            seconds = (int)(timer % 60);

            if (seconds == 5){
                Debug.Log("itens do banheiro");
                SceneManager.LoadScene("Parabens");
            }
        }
    }  

}
