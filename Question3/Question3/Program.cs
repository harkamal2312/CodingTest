using System;

namespace Question3
{
    class Program
    {
        private static void Main(string[] args)
        {
            var john = new Humanoid(new Dancing());
            Console.WriteLine(john.ShowSkill()); //print dancing

            var alex = new Humanoid(new Cooking());
            Console.WriteLine(alex.ShowSkill());//print cooking

            var bob = new Humanoid();
            Console.WriteLine(bob.ShowSkill());//print no skill is defined

        }
        public class Humanoid
        {
            private Skills skil = null;
            public Humanoid(Skills skils = null)
            {
                this.skil = skils;
            }

            public string ShowSkill()
            {
                var returnString = string.Empty;
                if (this.skil == null)
                {
                    returnString = "No skill is defined";
                }
                else
                {
                    switch (this.skil.GetType())
                    {
                        case Type dancing when dancing == typeof(Dancing):
                            returnString = "Dancing";
                            break;
                        case Type cooking when cooking == typeof(Cooking):
                            returnString = "Cooking";
                            break;
                        default:
                            break;
                    }
                }

                return returnString;
            }
        }


        private class Cooking : Skills
        {

        }

        private class Dancing : Skills
        {

        }

        public interface Skills
        {

        }
    }


}
