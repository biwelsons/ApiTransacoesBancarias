using System;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ApiTransacoesBancarias
{
    public class FiltroTransacao
{
    [JsonProperty(PropertyName = "Data")]
    public string? Data { get; set; }
    public string? ModoTransacao { get; set; }
    public string? Categoria { get; set; }
    public string? NotaObservacao { get; set; }
    public decimal? Valor { get; set; }
    public string? TipoValor { get; set; }
    public string? TipoTransacao { get; set; }

}
}