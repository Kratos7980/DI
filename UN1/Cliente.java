import java.io.*;
import java.net.*;

public class Cliente {
    public static void main(String[] args) {
        try (Socket socket = new Socket("localhost", 12345);
             BufferedReader entrada = new BufferedReader(new InputStreamReader(socket.getInputStream()));
             PrintWriter salida = new PrintWriter(socket.getOutputStream(), true);
             BufferedReader consola = new BufferedReader(new InputStreamReader(System.in))) {

            System.out.println("Conectado al servidor.");
            System.out.println(entrada.readLine()); // Solicita el nombre de usuario
            String nombreUsuario = consola.readLine();
            salida.println(nombreUsuario);

            // Hilo para escuchar mensajes del servidor
            new Thread(() -> {
                String mensajeServidor;
                try {
                    while ((mensajeServidor = entrada.readLine()) != null) {
                        System.out.println(mensajeServidor);
                    }
                } catch (IOException e) {
                    e.printStackTrace();
                }
            }).start();

            // Enviar mensajes al servidor
            String mensajeConsola;
            while ((mensajeConsola = consola.readLine()) != null) {
                salida.println(mensajeConsola);
            }
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
