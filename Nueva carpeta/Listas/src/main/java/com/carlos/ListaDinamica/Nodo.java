/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */

package com.carlos.ListaDinamica;

/**
 *
 *
 * @author KRATOS
 * @version 1.0
 * Created on 17 sept 2024
 */
public class Nodo <T>{
    //Atributos
    private T dato;
    private Nodo<T> siguiente;
    
    //Constructores
    /**
     * Por Defecto
     */
    public Nodo(){
        siguiente = null;
    }
    
    /**
    * Le pasamos un dato al nodo
    * @param p
    */
    public Nodo(T p){
        siguiente = null;
        dato = p;
    }
    
    /**
     * Le pasamos un dato y su siguiente nodo al nodo
     * 
     * @param t Dato a insetar
     * @param siguiente Su siguiente nodo
     */
    public Nodo(T t, Nodo<T> siguiente){
        this.siguiente = siguiente;
        dato = t;
    }
    
    //Getters/Setters
    
    public T getDato(){
        return dato;
    }
    
    public void setDato(T dato){
        this.dato = dato;
    }
    
    public Nodo<T> getSiguiente(){
        return siguiente;
    }
    
    public void setSiguiente(Nodo<T> siguiente){
        this.siguiente = siguiente;
    }
}
