using FilmOpgave_WEXO.DataAccessLayer.Interfaces;
using FilmOpgave_WEXO.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmOpgave_WEXO.DataAccessLayer
{
    class DbMovie : ICRUD<Movie>
    {
        public void Create(Movie entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Movie get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Movie> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(Movie entity)
        {
            throw new NotImplementedException();
        }
    }
}
