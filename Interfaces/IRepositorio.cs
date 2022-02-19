using System.Collections.Generic;
namespace DIO.Series.Interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista();
         T RetornaParId(int id);
         void Insere(T entidade);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}