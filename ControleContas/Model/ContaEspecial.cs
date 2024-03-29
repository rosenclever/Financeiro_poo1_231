﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleContas.Model
{
    public class ContaEspecial : Conta
    {
        public ContaEspecial(string numero, Cliente titular) : base(numero, titular)
        {
        }

        public ContaEspecial(string numero, decimal saldo, Cliente titular) : base(numero, saldo, titular)
        {
        }
        private decimal _limite = 1000;
        public decimal Limite
        {
            get
            {
                return _limite;
            }
            protected set
            {
                _limite = value;
            }
        }

        public override bool Sacar(decimal valor)
        {
            if (Saldo + Limite - valor - 0.10m < 0)
            {
                throw new ArgumentOutOfRangeException("Valor do Saque excedido", valor, SaqueMaiorQueSaldoMessage);
            }
            Saldo -= valor - 0.10m;
            return true;
        }
    }
}
