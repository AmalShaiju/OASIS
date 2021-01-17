using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OASIS.Data
{
    public class OASeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new OasisContext(
                serviceProvider.GetRequiredService<DbContextOptions<OasisContext>>()))
            {
            }
        }
    }
}
