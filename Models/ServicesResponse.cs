using System.Reflection.Metadata;

namespace WebAPI_Estudo.Models
{
    public class ServicesResponse<T>
    {
        public T? Dados { get; set; }

        public String Mensagem { get; set; } = string.Empty;

        public bool Sucesso { get; set; } = true;
    }
}
