using System.Text.Json.Serialization;

namespace WEBAPI_Funcionario.Enums {

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum {
        SPF,
        PO,
        RDO,
        Marketplace,
        ConteudoPortais,
        Financeiro,
        Facilities,
        RH,
        Infra,
    }
}
