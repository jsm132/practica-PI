using System;
using System.Collections;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.IO;
using System.Diagnostics;

namespace ESproject {
    public class Cliente {
        private static SslStream sslStream;
        private static TcpClient client;

        // The following method is invoked by the RemoteCertificateValidationDelegate.
        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors) {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }
        //inicia una conexión con el servidor
        public static void RunClient(string machineName, string serverName) {
            client = new TcpClient(machineName, 8080);
            Console.WriteLine("Client connected.");
            // Create an SSL stream that will close the client's stream.
            sslStream = new SslStream(client.GetStream(), false, delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; }, null);
            // The server name must match the name on the server certificate.
            try {
                sslStream.AuthenticateAsClient(serverName);
            } catch (AuthenticationException e) {
                Console.WriteLine("Exception: {0}", e.Message);
                if (e.InnerException != null) {
                    Console.WriteLine("Inner exception: {0}", e.InnerException.Message);
                }
                Console.WriteLine("Authentication failed - closing the connection.");
                client.Close();
                return;
            }
        }
        //cierra una conexión con el servidor
        public static void closeConnection() {
            WriteMessage("close");
            client.Close();
        }
        //envía una secuencia de bytes al servidor, espera la respuesta y la devuelve ((¡aún está sin probar!))
        public static string WriteBytes(byte[] file) {
            byte[] messsageSocket = file;
            // Send message to the server. 
            sslStream.Write(messsageSocket);
            sslStream.Flush();
            string response = ReadMessage();
            return response;
        }
        //envía un mensaje al servidor y espera hasta recibir una respuesta de este, luego la devuelve
        public static string WriteMessage(string message) {
            byte[] messsageSocket = Encoding.UTF8.GetBytes(message + "<EOF>");
            // Send message to the server. 
            sslStream.Write(messsageSocket);
            Console.WriteLine("Escribo: " + message);
            sslStream.Flush();
            if (message.Equals("close")) {
                return null;
            }
            string response = ReadMessage();
            return response;
        }
        //en principio no deberíamos recibir un mensaje del servidor a menos que sea una respuesta, así que por el momento se queda como método privado
        private static string ReadMessage() {
            byte[] buffer = new byte[2048];
            StringBuilder messageData = new StringBuilder();
            int bytes;
            do {
                bytes = sslStream.Read(buffer, 0, buffer.Length);

                // Use Decoder class to convert from bytes to UTF8
                // in case a character spans two buffers.
                Decoder decoder = Encoding.UTF8.GetDecoder();
                char[] chars = new char[decoder.GetCharCount(buffer, 0, bytes)];
                decoder.GetChars(buffer, 0, bytes, chars, 0);
                messageData.Append(chars);
                // Check for EOF.
                if (messageData.ToString().IndexOf("<EOF>") != -1) {
                    break;
                }
            } while (bytes != 0);

            if (messageData.Length > 0)
                return messageData.ToString(0, messageData.Length - 5);

            return messageData.ToString();
        }
        public static byte[] ReadBytes(int numBytes) {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            byte[] buffer = new byte[32768];
            byte[] fileData = new byte[0];
            int bytes;
            do {
                bytes = sslStream.Read(buffer, 0, buffer.Length);
                //fileData = appendByteArray(fileData, buffer);
                int startWritting = fileData.Length;
                Array.Resize(ref fileData, fileData.Length + bytes);
                Console.WriteLine("tamaño fileData {0}, bytes a copiar {1}", fileData.Length, bytes);
                Buffer.BlockCopy(buffer, 0, fileData, startWritting, bytes);
                Console.WriteLine("Leo {0} bytes más", bytes);
                Console.WriteLine("He leído {0} bytes de {1}", fileData.Length, numBytes);
            } while (fileData.Length < numBytes);
            sw.Stop();
            Console.WriteLine("{0} bytes descargados en {1} segundos, velocidad de descarga = {2} MB/s",
                fileData.Length, sw.Elapsed, (fileData.Length / 1000d) / sw.ElapsedMilliseconds);
            return fileData;
        }
    }
}