using System;
using System.Collections.Generic;

namespace SERVICIOS.SEGURIDAD.DOMINIO
{

    public abstract class FamiliaComponent
    {
        public string idfamilia { get; set; }
        public string nombre { get; set; }
        
        public FamiliaComponent()
        {
            this.idfamilia = Guid.NewGuid().ToString();
        }

        public abstract void Agregar(FamiliaComponent c);
        public abstract void Remover(FamiliaComponent c);
        public abstract List<Patente> GetAccesos();
        public abstract int GetChilds();

    }
}
