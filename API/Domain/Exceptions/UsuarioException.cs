namespace API.Domain.Exceptions
{
    public class UsuarioException : Exception
    {
        public UsuarioException() { }

        public UsuarioException(string mensagem) : base(mensagem) { }

        public UsuarioException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }

    public class UsuarioNaoEncontradoException : UsuarioException
    {
        public UsuarioNaoEncontradoException() { }

        public UsuarioNaoEncontradoException(string mensagem) : base(mensagem) { }

        public UsuarioNaoEncontradoException(string mensagem, Exception innerException) : base(mensagem, innerException) { }
    }
}
