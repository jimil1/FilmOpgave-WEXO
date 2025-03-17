using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmOpgave_WEXO.DataAccessLayer.Interfaces
{
    interface ICRUD<T>
    {
        void Create(T entity);
        T get(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(int id);
    }
}
    }
}
