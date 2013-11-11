using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAO
{
    public interface IDAO<T>
    {
        void Agregar(T dato);
        void Eliminar(T dato);
        void Modificar(T dato);

        //List<T> Listar_Todos();
        //T BuscarPorID(int id);
        //T BuscarPorNombre(String name);
    }
}
