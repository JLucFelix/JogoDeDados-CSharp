using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace ClasseDado
{
    public interface Dado
    {
        int Roll();
    }
    public class DadoNormal : Dado
    {
        private Random random;
        public DadoNormal()
        {
            random = new Random();
        }
        public int Roll()
        {
            return random.Next(1, 7);
        }
    }
    public class DadoViciado : Dado
    {
        private int[] numeros = { 1, 2, 3, 4, 5, 6, 6, 6, 6 };
        private Random random;

        public DadoViciado()
        {
            random = new Random();
        }
        public int Roll()
        {
            return numeros[random.Next(numeros.Length)];
        }
    }


    public class Jogo
    {

        private List<int> rolls;
        private Dado dado;
        public Jogo(Dado dado)
        {
            this.dado = dado;
            rolls = new List<int>();
        }
        public int RolarDado()
        {
            int resultado = dado.Roll();
            rolls.Add(resultado);
            return resultado;
        }
        public List<int> ObterHistorico()
        {
            return new List<int>(rolls);
        }
        public void Resetar()
        {
            rolls.Clear();
        }



    }

}
