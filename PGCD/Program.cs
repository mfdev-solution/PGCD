internal class Program
{
    private static void Main(string[] args)
    {
        //int nb1 = validerNombre("premiere valeure");
        //int nb2 = validerNombre("Deuxieme valeure");
        //Console.WriteLine ($"PGCD({nb1},{nb2}) = "+(calculPGCD(nb1, nb2)));
        Boolean toContinu = true;
        while(toContinu)
        {
            Console.WriteLine("Combien de nombres voulez vous calculer leur PGCD ?");
            int nbr = validerNombre();
            Console.WriteLine("Veillez renseigner ces nombres");
            int[] nombres = validerNombres(nbr);
            afficherPGCD(nombres);
            Console.WriteLine("Voulez vous continuer 1:oui 2:non");
            string ans = Console.ReadLine();
            toContinu=ans=="1"||ans=="oui"?true:false;
        }

    }
    /*
     * @param array
     * This function show the pgcd of n numbers
     */
    private static void afficherPGCD(int[] tab)
    {
        Console.Write("PGCD(");
        foreach(int i in tab) 
        { 
            Console.Write(i+" ");
        }
        Console.Write(") = "+caulerPGCDN(tab));
        Console.WriteLine();
    }
    /*
     * this function calculate the pgcd of n numbers
     */
    private static int caulerPGCDN(int[] tab)
    {   
        int pgcd = tab[0];
        for(int i = 1; i < tab.Length;i++)
        {
            int nb = pgcd ;
            pgcd = calculPGCD(nb, tab[i]);
        }

        return pgcd;
    }
    /**
     * This function permet to register a table of numbers 
     */
    private static int[] validerNombres(int nbr)
    {
        int[] tab  = new int[nbr];
        for(int n = 0; n < nbr; n++)
        {
            Console.WriteLine($"Entrez le nombre Numero : {n}");
            tab[n] = validerNombre();
        }

        return tab;
    }
    /**
     * this function calculate the pgcd of two numbers
     * 
     */
    private static int calculPGCD(int a , int b)
    {
        if(b == 0)
        {
            return a;
        }else
        {
            return calculPGCD(b, Math.Abs( a-b));
        }
    }
    /**
     * This permet to validate an integr input
     * 
     */
    private static int validerNombre(string message="")
    {
        Boolean isValid = false;
        int nbr = 0;
        while (isValid == false)
        {
            Console.WriteLine("Veillez entrer un nombre entier positif : "+message);
            try
            {
                string strnbr = Console.ReadLine();
                if (!int.TryParse(strnbr, out nbr)) throw new Exception(message:"Veillez entrer un nombre entier");
                nbr = Convert.ToInt32(nbr);
                if (2147483647 < nbr) throw new Exception(message:"Depacement de capacite");
                if (nbr < 0) throw new Exception(message: "Veillez entrez un nombre entier positif");
                isValid= true;

            }catch(Exception e) 
            {
                Console.WriteLine("Argument incorrecte "+e.Message);
            }
        }


        return nbr;
    }
    public class ClientBillingException : Exception
    {
        public ClientBillingException(string message)
           : base(message)
        {
        }
    }
}
