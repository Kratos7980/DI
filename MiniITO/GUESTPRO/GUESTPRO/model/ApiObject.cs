using GUESTPRO.manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUESTPRO.model
{
    internal class ApiObject
    {
        private ApiManage am;
        public Meta meta { get; set; }
        public Response response { get; set; }

        public ApiObject()
        {
            am = new ApiManage();
        }

        public Task<List<DateTime>> getFestivos()
        {
            return am.obtenerFestivos();
        }
    }
}
