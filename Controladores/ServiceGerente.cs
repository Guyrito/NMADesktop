using PersistenciaBD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controladores
{
    public class ServiceGerente : AbstractService<Gerente>
    {
        public override List<Gerente> GetEntities()
        {
            return nmaEn.Gerente.ToList<Gerente>();
        }

        public override Gerente GetEntity(object key)
        {
            return nmaEn.Gerente.Where(gerente => gerente.Cliente_id_clien == (int)key).FirstOrDefault<Gerente>();
        }
    }
}
