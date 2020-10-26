using ESproject._2sv;
using Server.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server {
    class Program {
        static int Main() {
            /*SecondStep ss = new SecondStep();
            EmailSender es = new EmailSender("vicentevicedoruiz@gmail.com", ss.getCode());
            es.Send();
            string codeintr = Console.ReadLine();
            if (ss.checkCode(codeintr)) {
                Console.WriteLine("Código correcto, acceso permitido");
            } else {
                Console.WriteLine("Código incorrecto, acceso no permitido");
            }
            Console.ReadKey();*/
            var certificate = "ssl-certificate.pfx";
            //certificate = "ssl-certificate.pfx";
            try {
                SslServer.RunServer(certificate);
            }
            catch(Exception e) {
                Console.WriteLine(e);
                Console.ReadKey();
            }
            Console.ReadKey();
            return 0;
        }
    }
}
