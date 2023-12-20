using System;
using System.ComponentModel.DataAnnotations;



namespace ApiTransacoesBancarias
{

    public enum ModoTransacao
    {
        Dinheiro,
        CartaoDeDebito,
        CartaoDeCredito,
        TransferenciaBancaria
    }

    public enum TipoTransacao {
        Receita,
        Despesa
    }

    public class Transacao
    {

        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime DataHora { get; set; }

        [EnumDataType(typeof(ModoTransacao))]
        public string? ModoTransacao { get; set; }
        public string? Categoria { get; set; }
        public string? NotaObservacao { get; set; }
        public decimal Valor { get; set; }

        [EnumDataType(typeof(TipoTransacao))]
        public string? TipoTransacao { get; set; }
    }


    

}
