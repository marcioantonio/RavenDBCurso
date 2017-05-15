using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class Cliente
    {
        public string id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public Endereco Endereco { get; set; }

    }
}
