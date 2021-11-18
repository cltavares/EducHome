using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanheiroManager : MonoBehaviour
{
    public GameObject sabonete, toalha,  chuveiro, shampoo, sabonetePreto, toalhaPreto, chuveiroPreto, shampooPreto;
    
    //banheiro
    Vector2 saboneteinitialPos, toalhainitialPos, shampooinitialPos, chuveiroinitialPos;
    public AudioSource pesquisaItensBanheiro;
    public AudioClip[] corretoItensBanheiro;
    public AudioClip inCorretoBanheiro;
    bool saboneteCorreto, toalhaCorreto, chuveiroCorreto, shampooCorreto = false;

    void Start(){
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
            saboneteCorreto = true;
        }else{
            sabonete.transform.position = saboneteinitialPos;
            pesquisaItensBanheiro.clip = inCorretoBanheiro;
            pesquisaItensBanheiro.Play();
        }
    } 

    public void DropToalha(){
        float Distance = Vector3.Distance(toalha.transform.position, toalhaPreto.transform.position);
        if (Distance < 50){
            toalha.transform.position = toalhaPreto.transform.position;
            pesquisaItensBanheiro.clip = corretoItensBanheiro[2];//[Random.Range(0, corretoItensBanheiro.Length)];
            pesquisaItensBanheiro.Play();
            toalhaCorreto = true;
        }else{
            toalha.transform.position = toalhainitialPos;
            pesquisaItensBanheiro.clip = inCorretoBanheiro;
            pesquisaItensBanheiro.Play();
        }
    }

    public void DropChuveiro(){
        float Distance = Vector3.Distance(chuveiro.transform.position, chuveiroPreto.transform.position);
        if (Distance < 50){
            chuveiro.transform.position = chuveiroPreto.transform.position;
            pesquisaItensBanheiro.clip = corretoItensBanheiro[0];//[Random.Range(0, corretoItensBanheiro.Length)];
            pesquisaItensBanheiro.Play();
            chuveiroCorreto = true;
        }else{
            chuveiro.transform.position = chuveiroinitialPos;
            pesquisaItensBanheiro.clip = inCorretoBanheiro;
            pesquisaItensBanheiro.Play();
        }
    } 

    public void DropShampoo(){
        float Distance = Vector3.Distance(shampoo.transform.position, shampooPreto.transform.position);
        if (Distance < 50){
            shampoo.transform.position = shampooPreto.transform.position;
            pesquisaItensBanheiro.clip = corretoItensBanheiro[3];//[Random.Range(0, corretoItensBanheiro.Length)];
            pesquisaItensBanheiro.Play();
            shampooCorreto = true;
        }else{
            shampoo.transform.position = shampooinitialPos;
            pesquisaItensBanheiro.clip = inCorretoBanheiro;
            pesquisaItensBanheiro.Play();
        }
    } 

    void Update(){
        if(toalhaCorreto && chuveiroCorreto && saboneteCorreto){
            Debug.Log("itens do banheiro");
        }
    }  

}
