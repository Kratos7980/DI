/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Main.java to edit this template
 */

package com.carlos.EjerciciosListas;

import static com.carlos.EjerciciosListas.MetodosExteriores.generaNumeroAleatorio;
import static com.carlos.EjerciciosListas.MetodosExteriores.generaNumeroRealAleatorio;
import com.carlos.ListaDinamica.ListaEnlazada;
import java.util.ArrayList;

/**
 *
 *
 * @author KRATOS
 * @version 1.0
 * Created on 17 sept 2024
 */
public class Ejercicio_2 {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        
        int pos = 0;
        int num = 1;
        double total = 0;
        
        
        System.out.println("Con ListaEnlazada");
        
        ListaEnlazada<Producto> lista = generarProducto();
        String[] ticket = new String[lista.cuantosElementos()];
        while(pos < lista.cuantosElementos()){
            Producto p = lista.devolverDato(pos);
            ticket[pos] = "Producto"+num+" "+p.getCantidad()+" "+p.getPrecio()+" "+p.precioFinal();
            total = total + p.precioFinal();
            num++;
            pos++;
        }
        for(String s:ticket){
            System.out.println(s);
        }
        System.out.printf("Precio final     %.2f\n",total);
        lista.listaVacia();
        
        System.out.println("--------------------");
        System.out.println("Con ArrayList");
        
        pos = 0;
        num = 1;
        total = 0;
        
        ArrayList<Producto> lista2 = generarProductoArray();
        String[] ticket2 = new String[lista2.size()];
        while(pos < lista2.size()){
            Producto p = lista2.get(pos);
            ticket2[pos] = "Producto"+num+" "+p.getCantidad()+" "+p.getPrecio()+" "+p.precioFinal();
            total = total + p.precioFinal();
            num++;
            pos++;
        }
        for(String s:ticket2){
            System.out.println(s);
        }
        System.out.printf("Precio final     %.2f",total);
        lista2.clear();
    }
    
    private static ListaEnlazada generarProducto(){
        ListaEnlazada<Producto> lista = new ListaEnlazada();
        int numProductos = generaNumeroAleatorio(1,8);
        int cont = 0;
        while(cont < numProductos){
            int cantidad = generaNumeroAleatorio(1,7);
            double precio = generaNumeroRealAleatorio(1.00,9.00);
            Producto p = new Producto(cantidad,precio);
            lista.insertarPrimero(p);
            cont++;
        }
        
        return lista;
    }
    
    private static ArrayList generarProductoArray(){
        ArrayList<Producto> lista = new ArrayList<>();
        int numProductos = generaNumeroAleatorio(1,8);
        int cont = 0;
        while(cont < numProductos){
            int cantidad = generaNumeroAleatorio(1,7);
            double precio = generaNumeroRealAleatorio(1.00,9.00);
            Producto p = new Producto(cantidad,precio);
            lista.add(p);
            cont++;
        }
        
        return lista;
    }

}
