using Appilcaion.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appilcation2.GenericOperations
{
    /*  public  class GetAllQuery<TEntity> where TEntity : class
      {
          public class Query : IRequest<IEnumerable<TEntity>> { }

          public class QueryHandler : IRequestHandler<Query,IEnumerable<TEntity>> {

             public IServiceStationDContext Context { get; }
              public DbSet<TEntity> table { get; set; }
          public QueryHandler(IServiceStationDContext context )
              {
                  Context = context;
                  table = this.Context.Set<TEntity>();

              }






          }





















      }*/
}
