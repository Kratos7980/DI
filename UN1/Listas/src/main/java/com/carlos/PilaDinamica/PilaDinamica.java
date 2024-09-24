/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.carlos.PilaDinamica;

/**
 *
 *
 * @author KRATOS
 * @version 1.0
 * Created on 17 sept 2024
 */
public class PilaDinamica <T>{
    //Atributos
    private Nodo<T>top; //Último nodo que se ha incluido.
    private int tamanio;
    
    //Constructores
    public PilaDinamica(){
        top = null; //No hay elemento.
        this.tamanio = 0;
    }
    //Metodos
    /**
     * Indica si está vacía o no.
     * @return
     */
    public boolean isEmpty(){
        return top==null;
    }
    /**
     * Indica el tamaño.
     * @return 
     */
    public int size(){
        return this.tamanio;
    }
    
    
    public T top(){
        if(isEmpty()){
            return null;
        }else{
            return top.getElemento();
        }
    }
    
    public T pop(){
        if(isEmpty()){
            return null;
        }else{
            T elemento = top.getElemento();
            Nodo<T> aux = top.getSiguiente();
            top = null;
            top = aux;
            this.tamanio--;
            return elemento;
        }       
    }
    
    public T push(T elemento){
        Nodo<T>aux = new Nodo<>(elemento,top);
        top = aux;
        this.tamanio++;
        return aux.getElemento();
    }
    
    @Override
    public String toString(){
        if(isEmpty()){
            return "La pila está vacía";
        }else{
            String resultado = "";
            Nodo<T>aux = top;
            while(aux!=null){
                resultado += aux.toString();
                aux=aux.getSiguiente();
            }
            return resultado;
        }
    }
}
