//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DemoDevWebApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBApirestEntities : DbContext
    {
        public DBApirestEntities()
            : base("name=DBApirestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clientes> Clientes { get; set; }
    
        public virtual ObjectResult<GetDatos_Result> GetDatos(Nullable<int> param1)
        {
            var param1Parameter = param1.HasValue ?
                new ObjectParameter("Param1", param1) :
                new ObjectParameter("Param1", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetDatos_Result>("GetDatos", param1Parameter);
        }
    }
}
