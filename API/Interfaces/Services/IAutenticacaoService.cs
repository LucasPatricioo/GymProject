using API.Data.DTO.Autenticacao;

namespace API.Interfaces.Services
{
    public interface IAutenticacaoService
    {
        string GerarToken(LoginAutenticacaoDTO loginRecebido);
    }
}
