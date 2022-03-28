using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_2
{
    class Data
    {
        private string question, answ1, answ2, answ3;
        private int rightAnsw;


        public string Question { get { return question; } set { question = value; } }
        public string Answ1 { get { return answ1; } set { answ1 = value; } }
        public string Answ2 { get { return answ2; } set { answ2 = value; } }
        public string Answ3 { get { return answ3; } set { answ3 = value; } }

        public int RightAnsw { get { return rightAnsw; } set { rightAnsw = value; } }



        public Data() { }

        public Data(string question, string answ1, string answ2, string answ3, int rightAnsw)
        {
            this.question = question;
            this.answ1 = answ1;
            this.answ2 = answ2;
            this.answ3 = answ3;
            this.rightAnsw = rightAnsw;
        }


    }
}
