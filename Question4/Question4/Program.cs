using System;

namespace Question4
{
    class Program
    {
        private static void Main(string[] args)
        {
            var alexa = new Alexa();
            Console.WriteLine(alexa.Talk()); //print hello, i am Alexa
            alexa.Configure(x =>
            {
                x.GreetingMessage = "Hello {OwnerName}, I'm at your service";
                x.OwnerName = "Bob Marley";
            });
           
            Console.WriteLine(alexa.Talk()); //print Hello Bob Marley, I'm at your service

            Console.WriteLine("press any key to exit ...");
            Console.ReadKey();
        }


        public class Alexa
        {     
            public string GreetingMessage { get; set; }

            public string OwnerName { get; set; }
            public string Talk()
            {
                if(!string.IsNullOrWhiteSpace(GreetingMessage) && !string.IsNullOrWhiteSpace(OwnerName))
                {
                    return GreetingMessage.Replace("{OwnerName}", OwnerName);
                }
                else
                {
                    return "hello, i am Alexa";
                }
            }

            internal void Configure(Action<Alexa> p)
            {
                p.Invoke(this);
            }
           
        }
    }
}
