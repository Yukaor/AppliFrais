using AppliFrais.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.Services
{
    public class SaveService : ISaveService
    {
        private readonly IBddContext _IBddContext;

        public SaveService(IBddContext iBddContext)
        {
            _IBddContext = iBddContext;

        }

        public void Save()
        {
            _IBddContext.MySaveChanges();
        }
    }
}
