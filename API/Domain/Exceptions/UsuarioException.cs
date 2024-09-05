namespace API.Domain.Exceptions
{
    public class UsuarioException : Exception
    {
        public UsuarioException() { }

        public UsuarioException(string message) : base(message) { }

        public UsuarioException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class UsuarioNaoEncontradoException : UsuarioException
    {
        public UsuarioNaoEncontradoException() { }

        public UsuarioNaoEncontradoException(string message) : base(message) { }

        public UsuarioNaoEncontradoException(string message, Exception innerException) : base(message, innerException) { }
    }
}
