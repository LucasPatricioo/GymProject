namespace API.Domain.Exceptions
{
    public class AutenticacaoException : Exception
    {
        public AutenticacaoException() { }
        public AutenticacaoException(string mensagem) : base(mensagem) { }
        public AutenticacaoException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}
