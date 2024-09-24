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
public class Nodo <T>{
    //Atributos
    private T elemento;
    private Nodo<T> siguiente;
    
    //Constructor
    public Nodo(T elemento, Nodo<T> siguiente){
        this.elemento = elemento;
        this.siguiente = siguiente;
    }
    
    //Getters/Setters
    public T getElemento(){
        return elemento;
    }
    public void setElemento(T elemento){
        this.elemento = elemento;
    }
    public Nodo<T> getSiguiente(){
        return siguiente;
    }
    public void setSiguiente(Nodo<T>siguiente){
        this.siguiente = siguiente;
    }
    
    @Override
    public String toString(){
        return elemento+"\n";
    }
}
