using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P2P借貸_MVC.Areas.AreaCollater.Models
{
    interface P2PRepository<T>
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        void Creat(T _Entity);

        void Update(T _Entity);

        void Delete(T _Entity);
    }
}
