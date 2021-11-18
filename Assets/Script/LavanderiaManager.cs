using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavanderiaManager : MonoBehaviour
{
   public GameObject maquinaLavar, sabaoPo, balde, varalRoupas,
    baldePreto, varalRoupasPreto, maquinaLavarPreto, sabaoPoPreto;
    
    
    
    //cozinha
    public AudioSource pesquisaItensLavanderia;
    Vector2 maquinaLavarinitialPos, sabaoPoinitialPos, baldeinitialPos, varalRoupasinitialPos;
    public AudioClip[] corretoItensLavanderia;
    public AudioClip[] inCorretoLavanderia;
    bool baldeCorreto, varalRoupasCorreto, maquinaLavarCorreto, sabaoPoCorreto = false;


    void Start(){
        pesquisaItensLavanderia = gameObject.GetComponent<AudioSource>();


        
        maquinaLavarinitialPos = maquinaLavar.transform.position;
        sabaoPoinitialPos = sabaoPo.transform.position;
        baldeinitialPos = balde.transform.position;
        varalRoupasinitialPos = varalRoupas.transform.position;

    }

    public void DragMaquinaLavar(){
        maquinaLavar.transform.position = Input.mousePosition;
    }

    public void DragSabaoPo(){
        sabaoPo.transform.position = Input.mousePosition;
    }

    public void DragBalde(){
        balde.transform.position = Input.mousePosition;
    }

    public void DragVaralRoupas(){
        varalRoupas.transform.position = Input.mousePosition;
    }


    public void DropMaquinaLavar(){
        float Distance = Vector3.Distance(maquinaLavar.transform.position, maquinaLavarPreto.transform.position);
        if (Distance < 50){
            maquinaLavar.transform.position = maquinaLavarPreto.transform.position;
            //pesquisaItensLavanderia.clip = corretoItensBanheiro[1];
            //pesquisaItensLavanderia.Play();
            maquinaLavarCorreto = true;
        }else{
            maquinaLavar.transform.position = maquinaLavarinitialPos;
            //pesquisaItensLavanderia.clip = inCorretoBanheiro;
            //pesquisaItensLavanderia.Play();
        }
    } 

    public void DropSabaoPo(){
        float Distance = Vector3.Distance(sabaoPo.transform.position, sabaoPoPreto.transform.position);
        if (Distance < 50){
            sabaoPo.transform.position = sabaoPoPreto.transform.position;
            //pesquisaItensLavanderia.clip = corretoItensBanheiro[2];
            //pesquisaItensLavanderia.Play();
            sabaoPoCorreto = true;
        }else{
            sabaoPo.transform.position = sabaoPoinitialPos;
            //pesquisaItensLavanderia.clip = inCorretoBanheiro;
            //pesquisaItensLavanderia.Play();
        }
    }

    public void DropBalde(){
        float Distance = Vector3.Distance(balde.transform.position, baldePreto.transform.position);
        if (Distance < 50){
            balde.transform.position = baldePreto.transform.position;
            //pesquisaItensLavanderia.clip = corretoItensBanheiro[0];
            //pesquisaItensLavanderia.Play();
            baldeCorreto = true;
        }else{
            balde.transform.position = baldeinitialPos;
            //pesquisaItensLavanderia.clip = inCorretoBanheiro;
            //pesquisaItensLavanderia.Play();
        }
    } 

    public void DropVaralRoupas(){
        float Distance = Vector3.Distance(varalRoupas.transform.position, varalRoupasPreto.transform.position);
        if (Distance < 50){
            varalRoupas.transform.position = varalRoupasPreto.transform.position;
            //pesquisaItensLavanderia.clip = corretoItensBanheiro[3];
            //pesquisaItensLavanderia.Play();
            varalRoupasCorreto = true;
        }else{
            varalRoupas.transform.position = varalRoupasinitialPos;
            //pesquisaItensLavanderia.clip = inCorretoBanheiro;
            //pesquisaItensLavanderia.Play();
        }
    } 

    



    void Update(){
    }  
}
